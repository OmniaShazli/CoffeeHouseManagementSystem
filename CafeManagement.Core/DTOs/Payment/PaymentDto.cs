using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Core.DTOs.Payment
{
	public class PaymentDto
	{
		public int Id { get; set; }

		public decimal Amount { get; set; }

		public string PaymentMethod { get; set; } = string.Empty;

		public string Status { get; set; } = string.Empty;

		public DateTime? PaidAt { get; set; }

		public int OrderId { get; set; }
	}
}
