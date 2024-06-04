using FerchauTest.Application.Contract.Cars.Dtos;
using FerchauTest.Shared.Application;

namespace FerchauTest.Application.Contract.Cars.Queries
{
	public class GetCarsQuery : IQuery<Pagination<CarDto>>
	{
		public GetCarsQuery(int pageSize, int pageCount)
		{
			PageSize = pageSize;
			PageCount = pageCount;
		}
		public int PageSize { get; set; }
		public int PageCount { get; set; }
	}
}
