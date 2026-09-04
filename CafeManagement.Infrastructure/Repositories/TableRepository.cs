using CafeManagement.Infrastructure.Repositories;
using CafeManagement.Core.Entities;
using CafeManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeManagement.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CafeManagement.Infrastructure.Repositories
{
	public class TableRepository
		: GenericRepository<Table>, ITableRepository
		{
			public TableRepository(ApplicationDbContext context)
				: base(context)
			{
			}

			public async Task<bool> ExistsAsync(int tableNumber)
			{
				return await _dbSet.AnyAsync(t => t.TableNumber == tableNumber);
			}

			public async Task<bool> ExistsForAnotherTableAsync(int tableNumber, int id)
			{
				return await _dbSet.AnyAsync(t =>
					t.TableNumber == tableNumber &&
					t.Id != id);
			}
		}
	
}
