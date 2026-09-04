using CafeManagement.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeManagement.Core.Interfaces.Services;
using CafeManagement.Core.DTOs.Auth;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Data;


namespace CafeManagement.Infrastructure.Services
{
	public class AuthService : IAuthService
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IConfiguration _configuration;
		public AuthService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
			_userManager = userManager;
			_configuration = configuration;
        }

		public async Task RegisterAsync(RegisterDto dto)
		{
			if (dto.Password != dto.ConfirmPassword)
			{
				throw new Exception("Passwords do not match.");
			}
			var user = new ApplicationUser
			{
				FirstName = dto.FirstName,
				LastName = dto.LastName,
				Email = dto.Email,
				UserName = dto.Email,
				PhoneNumber = dto.PhoneNumber
			};

			var result = await _userManager.CreateAsync(user, dto.Password);

			if (!result.Succeeded)
			{
				throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
			}

			await _userManager.AddToRoleAsync(user, "Customer");
		}

		public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
		{
			var user = await _userManager.FindByEmailAsync(dto.Email);

			if (user == null)
			{
				throw new Exception("Invalid email or password.");
			}

			var isPasswordValid = await _userManager.CheckPasswordAsync(user, dto.Password);

			if (!isPasswordValid)
			{
				throw new Exception("Invalid email or password.");
			}

			var token = await GenerateToken(user);
			return new AuthResponseDto
			{
				Token = token,
				Email = user.Email!,
				FullName = $"{user.FirstName} {user.LastName}",
				Expiration = DateTime.UtcNow.AddMinutes(
				Convert.ToDouble(_configuration["JWT:DurationInMinutes"]))
			};

		}

		private async Task<string> GenerateToken(ApplicationUser user)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.NameIdentifier, user.Id),
				new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
				new Claim(ClaimTypes.Email, user.Email!)
			};

			var roles = await _userManager.GetRolesAsync(user);

			foreach (var role in roles)
			{
				claims.Add(new Claim(ClaimTypes.Role, role));
			}

			var key = new SymmetricSecurityKey(
		Encoding.UTF8.GetBytes(_configuration["JWT:Key"]!));

			var credentials = new SigningCredentials(
		key,
		SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
	issuer: _configuration["JWT:Issuer"],
	audience: _configuration["JWT:Audience"],
	claims: claims,
	expires: DateTime.UtcNow.AddMinutes(
		Convert.ToDouble(_configuration["JWT:DurationInMinutes"])
	),
	signingCredentials: credentials
);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

	}
}
