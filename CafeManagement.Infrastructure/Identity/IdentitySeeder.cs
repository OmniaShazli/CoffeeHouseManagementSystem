using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CafeManagement.Infrastructure.Identity
{
	public static class IdentitySeeder
	{
		public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
		{
			if (!await roleManager.RoleExistsAsync("Admin"))
			{
				await roleManager.CreateAsync(new IdentityRole("Admin"));
			}

			if (!await roleManager.RoleExistsAsync("Customer"))
			{
				await roleManager.CreateAsync(new IdentityRole("Customer"));
			}

		}

		public static async Task SeedAdminAsync(UserManager<ApplicationUser> userManager)
		{
			var admin = await userManager.FindByEmailAsync("admin@cafe.com");

			if (admin == null)
			{
				var user = new ApplicationUser
				{
					FirstName = "System",
					LastName = "Admin",
					UserName = "admin@cafe.com",
					Email = "admin@cafe.com",
					EmailConfirmed = true
				};

				var result = await userManager.CreateAsync(user, "Admin@123");

				if (result.Succeeded)
				{
					await userManager.AddToRoleAsync(user, "Admin");
				}
				else
				{
					throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));
				}
			}
		}
	}
}
