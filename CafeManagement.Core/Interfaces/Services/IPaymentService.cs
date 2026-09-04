using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeManagement.Core.DTOs.Payment;

namespace CafeManagement.Core.Interfaces.Services
{
	public interface IPaymentService
	{
		Task<IEnumerable<PaymentDto>> GetAllAsync();

		Task<PaymentDto?> GetByIdAsync(int id);

		Task<PaymentDto?> GetByOrderIdAsync(int orderId);

		Task AddAsync(CreatePaymentDto dto);

		Task PayAsync(int orderId);
	}
}