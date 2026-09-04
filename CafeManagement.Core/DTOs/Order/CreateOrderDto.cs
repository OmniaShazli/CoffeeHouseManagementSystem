using CafeManagement.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CafeManagement.Core.Enums;

namespace CafeManagement.Core.DTOs.Order
{
	public class CreateOrderDto
	{
		[MinLength(1)]
		public List<CreateOrderItemDto> Items { get; set; } = new();

		[Required]
		public OrderType OrderType { get; set; }

		public int? TableId { get; set; }
	}
}