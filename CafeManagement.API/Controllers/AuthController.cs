using CafeManagement.Core.DTOs.Auth;
using CafeManagement.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CafeManagement.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AuthController: ControllerBase
	{
		private readonly IAuthService _authService;

		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register(RegisterDto dto)
		{
			await _authService.RegisterAsync(dto);

			return Ok(new
			{
				Message = "Registered Successfully"
			});
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login(LoginDto dto)
		{
			var result = await _authService.LoginAsync(dto);

			return Ok(result);
		}
	}
}
