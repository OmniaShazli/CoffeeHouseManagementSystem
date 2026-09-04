using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeManagement.Core.Enums;

namespace CafeManagement.Core.Entities
{

	public class Payment
	{
		public int Id { get; set; }

		public int OrderId { get; set; }

		public decimal Amount { get; set; }

		public PaymentMethod PaymentMethod { get; set; }

		public PaymentStatus Status { get; set; }

		public DateTime PaidAt { get; set; }

		public Order Order { get; set; } = null!;
	}
}
