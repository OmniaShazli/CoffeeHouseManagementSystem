using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Core.DTOs.MenuItem
{
	
		public class CreateMenuItemDto
		{
		[Required]
		[StringLength(100)]
		public string Name { get; set; } = string.Empty;

		[StringLength(500)]
		public string? Description { get; set; }

		[Range(0.01, 100000)]
		public decimal Price { get; set; }

		[Url]
		public string? ImageUrl { get; set; }

		[Range(1, int.MaxValue)]
		public int CategoryId { get; set; }
	}
	
}
