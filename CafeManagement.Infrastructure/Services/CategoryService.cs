using CafeManagement.Core.DTOs.Category;
using CafeManagement.Core.Entities;
using CafeManagement.Core.Interfaces.Repositories;
using CafeManagement.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Infrastructure.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _categoryRepository;

		public CategoryService(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		public async Task<IEnumerable<CategoryDto>> GetAllAsync()
		{
			var categories = await _categoryRepository.GetAllAsync();

			return categories.Select(c => new CategoryDto
			{
				Id = c.Id,
				Name = c.Name
			});

		}

		public async Task<CategoryDto?> GetByIdAsync(int id)
		{
			var category = await _categoryRepository.GetByIdAsync(id);

			if (category == null)
				return null;

			return new CategoryDto
			{
				Id = category.Id,
				Name = category.Name
			};
		}

		public async Task AddAsync(CreateCategoryDto dto)
		{
			if (await _categoryRepository.ExistsAsync(dto.Name))
			{
				throw new Exception("Category already exists.");
			}

			var category = new Category
			{
				Name = dto.Name
			};

			await _categoryRepository.AddAsync(category);

			await _categoryRepository.SaveChangesAsync();
		}

		public async Task UpdateAsync(UpdateCategoryDto dto)
		{
			var category = await _categoryRepository.GetByIdAsync(dto.Id);

			if (category == null)
				throw new Exception("Category not found.");

			if (await _categoryRepository.ExistsAsync(dto.Name))
			{
				throw new Exception("Category already exists.");
			}

			category.Name = dto.Name;

			_categoryRepository.Update(category);

			await _categoryRepository.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var category = await _categoryRepository.GetByIdAsync(id);

			if (category == null)
			{
				throw new Exception("Category not found.");
			}

			_categoryRepository.Delete(category);

			await _categoryRepository.SaveChangesAsync();
		}
	}
}
