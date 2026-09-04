using CafeManagement.Core.Entities;
using System;
using System.Collections.Generic;

namespace CafeManagement.Core.DTOs.Order
{
	public class OrderDto
	{
		public int Id { get; set; }

		public DateTime OrderDate { get; set; }

		public decimal TotalPrice { get; set; }

		public string Status { get; set; } = string.Empty;

		public string OrderType { get; set; } = string.Empty;

		public int? TableId { get; set; }

		public List<OrderItemDto> Items { get; set; } = new();
	}
}