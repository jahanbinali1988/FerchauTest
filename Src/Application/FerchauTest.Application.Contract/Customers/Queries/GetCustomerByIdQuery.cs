using FerchauTest.Application.Contract.Customers.Dtos;
using FerchauTest.Shared.Application;

namespace FerchauTest.Application.Contract.Customers.Queries
{
	public class GetCustomerByIdQuery : IQuery<CustomerDto?>
	{
		public GetCustomerByIdQuery(long customerId)
		{
			CustomerId = customerId;
		}
		public long CustomerId { get; init; }
	}
}
