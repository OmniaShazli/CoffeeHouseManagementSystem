using CafeManagement.Core.Entities;
using CafeManagement.Core.Interfaces.Repositories;
using CafeManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Infrastructure.Repositories
{
	public class MenuItemRepository
		       : GenericRepository<MenuItem>, IMenuItemRepository
	{
		public MenuItemRepository(ApplicationDbContext context)
		   : base(context)
		{
		}
		public async Task<IEnumerable<MenuItem>> GetByCategoryIdAsync(int categoryId)
		{
			return await _dbSet
				.Where(m => m.CategoryId == categoryId)
				.ToListAsync();
		}

		public async Task<bool> ExistsAsync(string name)
		{
			return await _dbSet.AnyAsync(m => m.Name == name);
		}
		public async Task<IEnumerable<MenuItem>> GetAllWithCategoryAsync()
		{
			return await _dbSet
				.Include(m => m.Category)
				.ToListAsync();
		}

		public async Task<MenuItem?> GetByIdWithCategoryAsync(int id)
		{
			return await _dbSet
				.Include(m => m.Category)
				.FirstOrDefaultAsync(m => m.Id == id);
		}

		public async Task<bool> ExistsForAnotherItemAsync(string name, int id)
		{
			return await _dbSet.AnyAsync(m =>
				m.Name == name &&
				m.Id != id);
		}
	}
}
