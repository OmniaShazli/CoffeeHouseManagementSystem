using CafeManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeManagement.Core.Enums;

namespace CafeManagement.Core.DTOs.Reservation
{
	public class UpdateReservationDto
	{
		public int Id { get; set; }

		public DateOnly ReservationDate { get; set; }

		public TimeOnly StartTime { get; set; }

		public TimeOnly EndTime { get; set; }

		[Range(1, 10)]
		public int NumberOfGuests { get; set; }

		[Range(1, int.MaxValue)]
		public int TableId { get; set; }

		public ReservationStatus Status { get; set; }
	}
}