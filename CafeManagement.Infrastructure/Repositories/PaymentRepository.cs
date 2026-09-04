using CafeManagement.Core.Entities;
using CafeManagement.Core.Interfaces.Repositories;
using CafeManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Infrastructure.Repositories
{
	public class PaymentRepository
	: GenericRepository<Payment>, IPaymentRepository
	{
		private readonly ApplicationDbContext _context;

		public PaymentRepository(ApplicationDbContext context)
			: base(context)
		{
			_context = context;
		}

		public async Task<Payment?> GetByOrderIdAsync(int orderId)
		{
			return await _context.Payments
				.FirstOrDefaultAsync(p => p.OrderId == orderId);
		}
	}
}
