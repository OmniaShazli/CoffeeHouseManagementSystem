using CafeManagement.Core.DTOs.MenuItem;
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
	public class MenuItemService: IMenuItemService
	{
		private readonly IMenuItemRepository _menuItemRepository;
		private readonly ICategoryRepository _categoryRepository;
		public MenuItemService(
			IMenuItemRepository menuItemRepository,
			ICategoryRepository categoryRepository)
		{
			_menuItemRepository = menuItemRepository;
			_categoryRepository = categoryRepository;
		}

		public async Task<IEnumerable<MenuItemDto>> GetAllAsync()
		{
			var menuItems = await _menuItemRepository.GetAllWithCategoryAsync();

			return menuItems.Select(m => new MenuItemDto
			{
				Id = m.Id,
				Name = m.Name,
				Description = m.Description,
				Price = m.Price,
				ImageUrl = m.ImageUrl,
				IsAvailable = m.IsAvailable,
				CategoryId = m.CategoryId,
				CategoryName = m.Category.Name
			});
		}

			public async Task<MenuItemDto?> GetByIdAsync(int id)
			{
			var menuItem = await _menuItemRepository.GetByIdWithCategoryAsync(id);

			if (menuItem == null)
				return null;

			return new MenuItemDto
			{
				Id = menuItem.Id,
				Name = menuItem.Name,
				Description = menuItem.Description,
				Price = menuItem.Price,
				ImageUrl = menuItem.ImageUrl,
				IsAvailable = menuItem.IsAvailable,
				CategoryId = menuItem.CategoryId,
				CategoryName = menuItem.Category.Name
			};
		}
		
			public async Task AddAsync(CreateMenuItemDto dto)
		{
			if (await _menuItemRepository.ExistsAsync(dto.Name))
			{
				throw new Exception("Menu item already exists.");
			}

			var category = await _categoryRepository.GetByIdAsync(dto.CategoryId);

			if (category == null)
			{
				throw new Exception("Category not found.");
			}

			var menuItem = new MenuItem
			{
				Name = dto.Name,
				Description = dto.Description,
				Price = dto.Price,
				ImageUrl = dto.ImageUrl,
				CategoryId = dto.CategoryId,
				IsAvailable = true
			};

			await _menuItemRepository.AddAsync(menuItem);

			await _menuItemRepository.SaveChangesAsync();
		}

		public async Task UpdateAsync(UpdateMenuItemDto dto)
		{
			var menuItem = await _menuItemRepository.GetByIdAsync(dto.Id);

			if (menuItem == null)
				throw new Exception("Menu item not found.");

			var category = await _categoryRepository.GetByIdAsync(dto.CategoryId);

			if (category == null)
				throw new Exception("Category not found.");

			if (await _menuItemRepository.ExistsForAnotherItemAsync(dto.Name, dto.Id))
				throw new Exception("Menu item already exists.");

			menuItem.Name = dto.Name;
			menuItem.Description = dto.Description;
			menuItem.Price = dto.Price;
			menuItem.ImageUrl = dto.ImageUrl;
			menuItem.IsAvailable = dto.IsAvailable;
			menuItem.CategoryId = dto.CategoryId;

			_menuItemRepository.Update(menuItem);

			await _menuItemRepository.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var menuItem = await _menuItemRepository.GetByIdAsync(id);

			if (menuItem == null)
			{
				throw new Exception("Menu item not found.");
			}

			_menuItemRepository.Delete(menuItem);

			await _menuItemRepository.SaveChangesAsync();
		}
	}
}
