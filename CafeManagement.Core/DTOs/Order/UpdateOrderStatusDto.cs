using CafeManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeManagement.Core.Enums;

namespace CafeManagement.Core.DTOs.Order
{
	public class UpdateOrderStatusDto
	{
		[Range(1, int.MaxValue)]
		public int Id { get; set; }

		public OrderStatus Status { get; set; }
	}
}
