using CafeManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Core.Interfaces.Repositories
{
	public interface IMenuItemRepository : IGenericRepository<MenuItem>
	{
		Task<IEnumerable<MenuItem>> GetByCategoryIdAsync(int categoryId);

		Task<bool> ExistsAsync(string name);

		Task<MenuItem?> GetByIdWithCategoryAsync(int id);

		Task<IEnumerable<MenuItem>> GetAllWithCategoryAsync();

		Task<bool> ExistsForAnotherItemAsync(string name, int id);

	}
}
