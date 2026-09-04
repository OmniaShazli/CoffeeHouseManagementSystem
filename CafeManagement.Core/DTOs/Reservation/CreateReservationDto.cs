using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Core.DTOs.Reservation
{
	public class CreateReservationDto
	{
		[Required]
		public DateOnly ReservationDate { get; set; }

		[Required]
		public TimeOnly StartTime { get; set; }

		[Required]
		public TimeOnly EndTime { get; set; }

		[Range(1, 10)]
		public int NumberOfGuests { get; set; }

		[Range(1, int.MaxValue)]
		public int TableId { get; set; }
	}
}
