using FerchauTest.Application.Contract.Customers.Dtos;
using FerchauTest.Application.Contract.Customers.Queries;
using FerchauTest.Persistence.EntityFramework.Persistence;
using FerchauTest.Shared.Application;
using Microsoft.EntityFrameworkCore;

namespace FerchauTest.Application.Customers.QueryHandlers
{
	internal class GetCustomersQueryHandler : IQueryHandler<GetCustomersQuery, Pagination<CustomerDto>>
	{
		private readonly FerchauDbContext _dbContext;
		public GetCustomersQueryHandler(FerchauDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<Pagination<CustomerDto>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
		{
			var totalCount = await _dbContext.Customers.CountAsync();
			var customers = await _dbContext.Customers
				.Select(s => new CustomerDto(s.Id, s.Firstname.Value, s.Lastname.Value, s.PhoneNumber.Value))
				.ToListAsync();

			return new Pagination<CustomerDto>() { Items = customers, TotalItems = totalCount };
		}
	}
}
