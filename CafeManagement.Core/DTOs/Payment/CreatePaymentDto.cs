using CafeManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeManagement.Core.Enums;

namespace CafeManagement.Core.DTOs.Payment
{
	public class CreatePaymentDto
	{
		[Range(1, int.MaxValue)]
		public int OrderId { get; set; }

		[Range(0.01, 100000)]
		public decimal Amount { get; set; }

		public PaymentMethod PaymentMethod { get; set; }
	}
}