using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Core.DTOs.Table
{
	public class CreateTableDto
	{
		[Range(1, int.MaxValue)]
		public int TableNumber { get; set; }

		[Range(2, 10)]
		public int Capacity { get; set; }
	}
}
