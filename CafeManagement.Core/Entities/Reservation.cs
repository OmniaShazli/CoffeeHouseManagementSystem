using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeManagement.Core.Enums;

namespace CafeManagement.Core.Entities
{
	public class Reservation
	{
		public int Id { get; set; }

		public DateOnly ReservationDate { get; set; }

		public TimeOnly StartTime { get; set; }

		public TimeOnly EndTime { get; set; }

		[Range(1, 10)]
		public int NumberOfGuests { get; set; }

		public ReservationStatus Status { get; set; }

		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

		public string UserId { get; set; } = string.Empty;

		public int TableId { get; set; }

		public Table Table { get; set; } = null!;
	}
}
