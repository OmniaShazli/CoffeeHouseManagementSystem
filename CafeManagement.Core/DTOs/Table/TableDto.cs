using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Core.DTOs.Table
{
	public class TableDto
	{
		public int Id { get; set; }

		public int TableNumber { get; set; }

		public int Capacity { get; set; }

		public bool IsAvailable { get; set; }
	}
}
