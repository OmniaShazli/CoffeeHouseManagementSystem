using CafeManagement.Core.DTOs.Order;
using CafeManagement.Core.Entities;
using CafeManagement.Core.Interfaces.Repositories;
using CafeManagement.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafeManagement.Core.Enums;

namespace CafeManagement.Infrastructure.Services
{
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _orderRepository;
		private readonly IMenuItemRepository _menuItemRepository;

		public OrderService(
			IOrderRepository orderRepository,
			IMenuItemRepository menuItemRepository)
		{
			_orderRepository = orderRepository;
			_menuItemRepository = menuItemRepository;
		}

		public async Task<IEnumerable<OrderDto>> GetAllAsync()
		{
			var orders =
				await _orderRepository.GetAllWithItemsAsync();

			return orders.Select(o => new OrderDto
			{
				Id = o.Id,

				OrderDate = o.OrderDate,

				TotalPrice = o.TotalPrice,

				Status = o.Status.ToString(),

				OrderType = o.OrderType.ToString(),

				TableId = o.TableId,

				Items = o.OrderItems.Select(i => new OrderItemDto
				{
					MenuItemId = i.MenuItemId,

					MenuItemName = i.MenuItem.Name,

					Quantity = i.Quantity,

					UnitPrice = i.UnitPrice

				}).ToList()
			});
		}

		public async Task<OrderDto?> GetByIdAsync(int id)
		{
			var order =
				await _orderRepository.GetByIdWithItemsAsync(id);

			if (order == null)
				return null;

			return new OrderDto
			{
				Id = order.Id,

				OrderDate = order.OrderDate,

				TotalPrice = order.TotalPrice,

				Status = order.Status.ToString(),

				OrderType = order.OrderType.ToString(),

				TableId = order.TableId,

				Items = order.OrderItems.Select(i => new OrderItemDto
				{
					MenuItemId = i.MenuItemId,

					MenuItemName = i.MenuItem.Name,

					Quantity = i.Quantity,

					UnitPrice = i.UnitPrice

				}).ToList()
			};
		}

		public async Task<IEnumerable<OrderDto>> GetUserOrdersAsync(
			string userId)
		{
			var orders =
				await _orderRepository.GetUserOrdersAsync(userId);

			return orders.Select(o => new OrderDto
			{
				Id = o.Id,

				OrderDate = o.OrderDate,

				TotalPrice = o.TotalPrice,

				Status = o.Status.ToString(),

				OrderType = o.OrderType.ToString(),

				TableId = o.TableId,

				Items = o.OrderItems.Select(i => new OrderItemDto
				{
					MenuItemId = i.MenuItemId,

					MenuItemName = i.MenuItem.Name,

					Quantity = i.Quantity,

					UnitPrice = i.UnitPrice

				}).ToList()
			});
		}

		public async Task AddAsync(
			CreateOrderDto dto,
			string userId)
		{

			if (!Enum.IsDefined(
				typeof(OrderType),
				dto.OrderType))
			{
				throw new Exception(
					"Invalid order type.");
			}

			if (dto.OrderType == OrderType.DineIn)
			{
				if (!dto.TableId.HasValue ||
					dto.TableId.Value <= 0)
				{
					throw new Exception(
						"Table is required for DineIn orders.");
				}
			}

			if (dto.OrderType == OrderType.TakeAway)
			{
				dto.TableId = null;
			}

			var order = new Order
			{
				OrderDate = DateTime.UtcNow,

				UserId = userId,

				Status = OrderStatus.Pending,

				OrderType = dto.OrderType,

				TableId = dto.TableId
			};

			decimal total = 0;

			foreach (var item in dto.Items)
			{
				var menuItem =
					await _menuItemRepository
						.GetByIdAsync(item.MenuItemId);

				if (menuItem == null)
				{
					throw new Exception(
						"Menu item not found.");
				}

				if (!menuItem.IsAvailable)
				{
					throw new Exception(
						$"{menuItem.Name} is not available.");
				}

				total +=
					menuItem.Price *
					item.Quantity;

				order.OrderItems.Add(
					new OrderItem
					{
						MenuItemId = menuItem.Id,

						Quantity = item.Quantity,

						UnitPrice = menuItem.Price
					});
			}

			order.TotalPrice = total;

			await _orderRepository.AddAsync(order);

			await _orderRepository.SaveChangesAsync();
		}

		public async Task UpdateStatusAsync(
			UpdateOrderStatusDto dto)
		{
			var order =
				await _orderRepository
					.GetByIdAsync(dto.Id);

			if (order == null)
			{
				throw new Exception(
					"Order not found.");
			}

			if (!Enum.IsDefined(
				typeof(OrderStatus),
				dto.Status))
			{
				throw new Exception(
					"Invalid order status.");
			}

			order.Status = dto.Status;

			_orderRepository.Update(order);

			await _orderRepository.SaveChangesAsync();
		}
	}
}