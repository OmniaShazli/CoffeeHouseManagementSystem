using CafeManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Core.Interfaces.Repositories
{
	public interface IOrderRepository : IGenericRepository<Order>
	{
		Task<IEnumerable<Order>> GetAllWithItemsAsync();

		Task<Order?> GetByIdWithItemsAsync(int id);

		Task<IEnumerable<Order>> GetUserOrdersAsync(string userId);
	}
}
