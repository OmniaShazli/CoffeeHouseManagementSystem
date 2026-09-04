using CafeManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using CafeManagement.Core.Interfaces.Repositories;
using CafeManagement.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeManagement.Infrastructure.Repositories
{
	public class OrderRepository
		: GenericRepository<Order>, IOrderRepository
	{
		private readonly ApplicationDbContext _context;

		public OrderRepository(
			ApplicationDbContext context)
			: base(context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Order>>
			GetAllWithItemsAsync()
		{
			return await _context.Orders
				.Include(o => o.OrderItems)
				.ThenInclude(oi => oi.MenuItem)
				.ToListAsync();
		}

		public async Task<Order?>
			GetByIdWithItemsAsync(int id)
		{
			return await _context.Orders
				.Include(o => o.OrderItems)
				.ThenInclude(oi => oi.MenuItem)
				.FirstOrDefaultAsync(
					o => o.Id == id);
		}

		public async Task<IEnumerable<Order>>
			GetUserOrdersAsync(string userId)
		{
			return await _context.Orders
				.Include(o => o.OrderItems)
				.ThenInclude(oi => oi.MenuItem)
				.Where(o => o.UserId == userId)
				.ToListAsync();
		}
	}
}