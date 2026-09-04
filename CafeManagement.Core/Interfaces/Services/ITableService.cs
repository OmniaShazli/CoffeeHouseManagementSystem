using CafeManagement.Core.DTOs.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Core.Interfaces.Services
{

		public interface ITableService
		{
			Task<IEnumerable<TableDto>> GetAllAsync();

			Task<TableDto?> GetByIdAsync(int id);

			Task AddAsync(CreateTableDto dto);

			Task UpdateAsync(UpdateTableDto dto);

			Task DeleteAsync(int id);
		}
	
}
