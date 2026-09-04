using CafeManagement.Core.DTOs.Category;
using CafeManagement.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CafeManagement.API.Controllers
{
	[Authorize(Roles = "Admin,Customer")]
	[ApiController]
	[Route("api/[controller]")]
	public class CategoryController:ControllerBase
	{
		private readonly ICategoryService _categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var categories = await _categoryService.GetAllAsync();

			return Ok(categories);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var category = await _categoryService.GetByIdAsync(id);

			if (category == null)
				return NotFound();

			return Ok(category);
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateCategoryDto dto)
		{
			await _categoryService.AddAsync(dto);

			return Ok("Category Created Successfully");
		}

		[HttpPut]
		public async Task<IActionResult> Update(UpdateCategoryDto dto)
		{
			await _categoryService.UpdateAsync(dto);

			return Ok("Category Updated Successfully");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _categoryService.DeleteAsync(id);

			return Ok("Category Deleted Successfully");
		}
	}
}
