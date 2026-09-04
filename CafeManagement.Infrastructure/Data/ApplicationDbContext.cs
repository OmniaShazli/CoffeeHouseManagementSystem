using CafeManagement.Core.Entities;
using CafeManagement.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CafeManagement.Infrastructure.Data
{
	public class ApplicationDbContext
		: IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(
			DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(
			ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<Payment>()
				.HasOne(p => p.Order)
				.WithOne(o => o.Payment)
				.HasForeignKey<Payment>(
					p => p.OrderId);

			builder.Entity<MenuItem>()
				.Property(m => m.Price)
				.HasPrecision(10, 2);

			builder.Entity<Order>()
				.Property(o => o.TotalPrice)
				.HasPrecision(10, 2);

			builder.Entity<Order>()
				.Property(o => o.OrderType)
				.HasConversion<string>();

			builder.Entity<OrderItem>()
				.Property(oi => oi.UnitPrice)
				.HasPrecision(10, 2);
		}

		public DbSet<Category> Categories { get; set; }

		public DbSet<MenuItem> MenuItems { get; set; }

		public DbSet<Table> Tables { get; set; }

		public DbSet<Reservation> Reservations { get; set; }

		public DbSet<Order> Orders { get; set; }

		public DbSet<OrderItem> OrderItems { get; set; }

		public DbSet<Payment> Payments { get; set; }
	}
}