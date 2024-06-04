using FerchauTest.Domain.Customers;
using FerchauTest.Shared.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerchauTest.Domain.Cars
{
	public interface ICarRepository : IRepository<Customer, long>
	{
	}
}
