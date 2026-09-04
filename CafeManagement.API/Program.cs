using CafeManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using CafeManagement.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using CafeManagement.Core.Interfaces.Services;
using CafeManagement.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.Tasks;
using CafeManagement.Core.Interfaces.Repositories;
using CafeManagement.Infrastructure.Repositories;


namespace CafeManagement.API
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();

			builder.Services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseSqlServer(
					builder.Configuration.GetConnectionString("DefaultConnection"));
			});

			builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
	.AddEntityFrameworkStores<ApplicationDbContext>()
	.AddDefaultTokenProviders();

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
			builder.Services.AddScoped<ICategoryService, CategoryService>();

			builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();
			builder.Services.AddScoped<IMenuItemService, MenuItemService>();
			builder.Services.AddScoped<IAuthService, AuthService>();

			builder.Services.AddScoped<ITableRepository, TableRepository>();
			builder.Services.AddScoped<ITableService, TableService>();
			builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

			builder.Services.AddScoped<IReservationService, ReservationService>();
			builder.Services.AddScoped<IOrderRepository, OrderRepository>();

			builder.Services.AddScoped<IOrderService, OrderService>();
			builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

			builder.Services.AddScoped<IPaymentService, PaymentService>();


			builder.Services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
.AddJwtBearer(options =>
{
	options.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,

		ValidIssuer = builder.Configuration["JWT:Issuer"],
		ValidAudience = builder.Configuration["JWT:Audience"],

		IssuerSigningKey = new SymmetricSecurityKey(
			Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]!)
		)
	};
});



			var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider
                    .GetRequiredService<ApplicationDbContext>();

                await DbSeeder.SeedAsync(context);
            }

            using (var scope = app.Services.CreateScope())
			{
				var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
				var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

				await IdentitySeeder.SeedRolesAsync(roleManager);
				await IdentitySeeder.SeedAdminAsync(userManager);
			}

			
				app.UseSwagger();
				app.UseSwaggerUI();
			

			app.UseHttpsRedirection();

			app.UseAuthentication();

			app.UseAuthorization();

			app.UseDefaultFiles();
			app.UseStaticFiles();


			app.MapControllers();

			app.Run();
		}
	}
}
