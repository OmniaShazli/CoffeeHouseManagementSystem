using CafeManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Core.Interfaces.Repositories
{
	public interface IPaymentRepository : IGenericRepository<Payment>
	{
		Task<Payment?> GetByOrderIdAsync(int orderId);
	}
}
