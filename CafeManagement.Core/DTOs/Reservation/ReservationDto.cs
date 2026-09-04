using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Core.DTOs.Reservation
{
	public class ReservationDto
	{
		public int Id { get; set; }

		public DateOnly ReservationDate { get; set; }

		public TimeOnly StartTime { get; set; }

		public TimeOnly EndTime { get; set; }

		public int NumberOfGuests { get; set; }

		public string Status { get; set; } = string.Empty;

		public int TableId { get; set; }

		public int TableNumber { get; set; }
	}
}
