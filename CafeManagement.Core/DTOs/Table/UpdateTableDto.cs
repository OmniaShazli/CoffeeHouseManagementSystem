using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Core.DTOs.Table
{

	public class UpdateTableDto
	{
		public int Id { get; set; }

		[Range(1, int.MaxValue)]
		public int TableNumber { get; set; }

		public int Capacity { get; set; }

		public bool IsAvailable { get; set; }
	}
}
