using CafeManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Core.Interfaces.Repositories
{
	
		public interface ICategoryRepository : IGenericRepository<Category>
		{
			Task<Category?> GetByNameAsync(string name);

			Task<bool> ExistsAsync(string name);



	}
	}

