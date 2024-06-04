using FerchauTest.Domain.Customers;
using FerchauTest.Persistence.EntityFramework.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerchauTest.Persistence.EntityFramework.Domain.Customers
{
	public class CustomerRepository : RepositoryBase<Customer, long>, ICustomerRepository
	{
		public CustomerRepository(FerchauDbContext dbContext) : base(dbContext)
		{
		}

		public Task<bool> AnyAsync(long id)
		{
			return DbContext.Customers.AnyAsync(c => c.Id == id);
		}
	}
}
