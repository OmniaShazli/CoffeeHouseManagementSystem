using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Core.DTOs.Order
{
	public class CreateOrderItemDto
	{
		[Range(1, int.MaxValue)]
		public int MenuItemId { get; set; }

		[Range(1, 100)]
		public int Quantity { get; set; }
	}
}
