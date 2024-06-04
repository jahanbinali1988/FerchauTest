using FerchauTest.Application.Contract.Customers.Dtos;
using FerchauTest.Shared.Application;

namespace FerchauTest.Application.Contract.Customers.Queries
{
	public class GetCustomersQuery : IQuery<Pagination<CustomerDto>>
	{
		public GetCustomersQuery(int pageSize, int pageCount)
		{
			PageSize = pageSize;
			PageCount = pageCount;
		}
		public int PageSize { get; set; }
		public int PageCount { get; set; }
	}
}
