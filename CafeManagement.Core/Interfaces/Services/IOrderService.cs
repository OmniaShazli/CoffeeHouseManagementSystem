using CafeManagement.Core.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Core.Interfaces.Services
{
	public interface IOrderService
	{
		Task<IEnumerable<OrderDto>> GetAllAsync();

		Task<OrderDto?> GetByIdAsync(int id);

		Task<IEnumerable<OrderDto>> GetUserOrdersAsync(string userId);

		Task AddAsync(CreateOrderDto dto, string userId);

		Task UpdateStatusAsync(UpdateOrderStatusDto dto);
	}
}
