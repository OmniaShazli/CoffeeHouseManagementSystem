using CafeManagement.Core.DTOs.Category;
using CafeManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Core.Interfaces.Services
{
	public interface ICategoryService
	{
		Task<IEnumerable<CategoryDto>> GetAllAsync();

		Task<CategoryDto?> GetByIdAsync(int id);

		Task AddAsync(CreateCategoryDto dto);

		Task UpdateAsync(UpdateCategoryDto dto);

		Task DeleteAsync(int id);
	}
}
