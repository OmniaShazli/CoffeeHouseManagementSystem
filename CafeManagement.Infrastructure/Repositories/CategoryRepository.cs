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
	public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
	{
		public CategoryRepository(ApplicationDbContext context)
			: base(context)
		{
		}

		public async Task<Category?> GetByNameAsync(string name)
		{
			return await _dbSet.FirstOrDefaultAsync(c => c.Name == name);
		}

		public async Task<bool> ExistsAsync(string name)
		{
			return await _dbSet.AnyAsync(c => c.Name == name);
		}
		
	}
}
