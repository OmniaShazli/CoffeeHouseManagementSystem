using System;
using System.Collections.Generic;
using CafeManagement.Core.Enums;

namespace CafeManagement.Core.Entities
{

	public class Order
	{
		public int Id { get; set; }

		public DateTime OrderDate { get; set; }

		public decimal TotalPrice { get; set; }

		public OrderStatus Status { get; set; }

		public string UserId { get; set; } = string.Empty;

		public OrderType OrderType { get; set; }

		public int? TableId { get; set; }

		public ICollection<OrderItem> OrderItems { get; set; }
			= new List<OrderItem>();

		public Payment? Payment { get; set; }
	}
}