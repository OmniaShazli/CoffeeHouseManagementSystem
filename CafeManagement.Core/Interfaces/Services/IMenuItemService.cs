using CafeManagement.Core.DTOs.MenuItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Core.Interfaces.Services
{
	public interface IMenuItemService
	{
		Task<IEnumerable<MenuItemDto>> GetAllAsync();

		Task<MenuItemDto?> GetByIdAsync(int id);

		Task AddAsync(CreateMenuItemDto dto);

		Task UpdateAsync(UpdateMenuItemDto dto);

		Task DeleteAsync(int id);
	}
}
