using CafeManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeManagement.Core.Entities;


namespace CafeManagement.Core.Interfaces.Repositories
{
	public interface ITableRepository : IGenericRepository<Table>
	{
		Task<bool> ExistsAsync(int tableNumber);

		Task<bool> ExistsForAnotherTableAsync(int tableNumber, int id);
	}
}
