using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Core.DTOs.Order
{
	public class OrderItemDto
	{
		public int MenuItemId { get; set; }

		public string MenuItemName { get; set; } = string.Empty;

		public int Quantity { get; set; }

		public decimal UnitPrice { get; set; }
	}
}
