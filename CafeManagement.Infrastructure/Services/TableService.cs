using CafeManagement.Core.DTOs.Table;
using CafeManagement.Core.Interfaces.Repositories;
using CafeManagement.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeManagement.Core.Entities;

namespace CafeManagement.Infrastructure.Services
{
	public class TableService : ITableService
	{
		private readonly ITableRepository _tableRepository;

		public TableService(ITableRepository tableRepository)
		{
			_tableRepository = tableRepository;
		}

		public async Task<IEnumerable<TableDto>> GetAllAsync()
		{
			var tables = await _tableRepository.GetAllAsync();

			return tables.Select(t => new TableDto
			{
				Id = t.Id,
				TableNumber = t.TableNumber,
				Capacity = t.Capacity,
				IsAvailable = t.IsAvailable
			});
		}

		public async Task<TableDto?> GetByIdAsync(int id)
		{
			var table = await _tableRepository.GetByIdAsync(id);

			if (table == null)
				return null;

			return new TableDto
			{
				Id = table.Id,
				TableNumber = table.TableNumber,
				Capacity = table.Capacity,
				IsAvailable = table.IsAvailable
			};
		}

		public async Task AddAsync(CreateTableDto dto)
		{
			if (await _tableRepository.ExistsAsync(dto.TableNumber))
			{
				throw new Exception("Table number already exists.");
			}

			if (dto.Capacity != 2 && dto.Capacity != 5 && dto.Capacity != 10)
			{
				throw new Exception("Table capacity must be 2, 5, or 10.");
			}

			var table = new Table
			{
				TableNumber = dto.TableNumber,
				Capacity = dto.Capacity,
				IsAvailable = true
			};

			await _tableRepository.AddAsync(table);

			await _tableRepository.SaveChangesAsync();
		}

		public async Task UpdateAsync(UpdateTableDto dto)
		{
			var table = await _tableRepository.GetByIdAsync(dto.Id);

			if (table == null)
				throw new Exception("Table not found.");

			if (await _tableRepository.ExistsForAnotherTableAsync(dto.TableNumber, dto.Id))
				throw new Exception("Table number already exists.");

			if (dto.Capacity != 2 && dto.Capacity != 5 && dto.Capacity != 10)
			{
				throw new Exception("Table capacity must be 2, 5, or 10.");
			}

			table.TableNumber = dto.TableNumber;
			table.Capacity = dto.Capacity;
			table.IsAvailable = dto.IsAvailable;

			_tableRepository.Update(table);

			await _tableRepository.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var table = await _tableRepository.GetByIdAsync(id);

			if (table == null)
				throw new Exception("Table not found.");

			_tableRepository.Delete(table);

			await _tableRepository.SaveChangesAsync();
		}
	}
}
