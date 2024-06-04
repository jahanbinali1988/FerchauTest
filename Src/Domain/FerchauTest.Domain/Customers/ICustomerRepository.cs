using FerchauTest.Shared.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerchauTest.Domain.Customers
{
	public interface ICustomerRepository : IRepository<Customer, long>
	{
		Task<bool> AnyAsync(long id);
	}
}
