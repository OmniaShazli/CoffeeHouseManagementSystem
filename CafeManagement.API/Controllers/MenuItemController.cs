using CafeManagement.Core.DTOs.MenuItem;
using CafeManagement.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CafeManagement.API.Controllers
{
	[Authorize(Roles = "Admin,Customer")]
	[Route("api/[controller]")]
	[ApiController]
	public class MenuItemController : ControllerBase
	{
		private readonly IMenuItemService _menuItemService;

		public MenuItemController(IMenuItemService menuItemService)
		{
			_menuItemService = menuItemService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var menuItems = await _menuItemService.GetAllAsync();

			return Ok(menuItems);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var menuItem = await _menuItemService.GetByIdAsync(id);

			if (menuItem == null)
				return NotFound("Menu item not found.");

			return Ok(menuItem);
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateMenuItemDto dto)
		{
			await _menuItemService.AddAsync(dto);

			return Ok("Menu item created successfully.");
		}

		[HttpPut]
		public async Task<IActionResult> Update(UpdateMenuItemDto dto)
		{
			await _menuItemService.UpdateAsync(dto);

			return Ok("Menu item updated successfully.");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _menuItemService.DeleteAsync(id);

			return Ok("Menu item deleted successfully.");
		}
	}
}
