using CafeManagement.Core.DTOs.Table;
using CafeManagement.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CafeManagement.API.Controllers
{
	[Authorize(Roles = "Admin,Customer")]
	[Route("api/[controller]")]
	[ApiController]
	public class TableController : ControllerBase
	{
		private readonly ITableService _tableService;

		public TableController(ITableService tableService)
		{
			_tableService = tableService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var tables = await _tableService.GetAllAsync();

			return Ok(tables);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var table = await _tableService.GetByIdAsync(id);

			if (table == null)
				return NotFound("Table not found.");

			return Ok(table);
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateTableDto dto)
		{
			await _tableService.AddAsync(dto);

			return Ok("Table created successfully.");
		}

		[HttpPut]
		public async Task<IActionResult> Update(UpdateTableDto dto)
		{
			await _tableService.UpdateAsync(dto);

			return Ok("Table updated successfully.");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _tableService.DeleteAsync(id);

			return Ok("Table deleted successfully.");
		}
	}
}