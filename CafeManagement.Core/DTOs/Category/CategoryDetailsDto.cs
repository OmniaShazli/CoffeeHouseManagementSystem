using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeManagement.Core.DTOs.MenuItem;

namespace CafeManagement.Core.DTOs.Category
{
	public class CategoryDetailsDto
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public List<MenuItemDto> MenuItems { get; set; } = new();
	}
}
