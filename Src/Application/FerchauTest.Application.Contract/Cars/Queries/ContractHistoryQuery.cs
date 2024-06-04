using FerchauTest.Application.Contract.Cars.Dtos;
using FerchauTest.Shared.Application;

namespace FerchauTest.Application.Cars.QueryHandlers
{
	public class ContractHistoryQuery : IQuery<ReportDto>
	{
		public long? CustomerId { get; init; }
		public int PageCount { get; init; }
		public int PageSize { get; init; }

		public ContractHistoryQuery(long? customerId, int pageSize, int pageCount)
		{
			this.CustomerId = customerId;
			this.PageCount = pageCount;
			this.PageSize = pageSize;
		}
	}
}
