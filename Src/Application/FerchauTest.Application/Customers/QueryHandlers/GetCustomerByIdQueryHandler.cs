using FerchauTest.Application.Contract.Customers.Dtos;
using FerchauTest.Application.Contract.Customers.Queries;
using FerchauTest.Persistence.EntityFramework.Persistence;
using FerchauTest.Shared.Application;
using Microsoft.EntityFrameworkCore;

namespace FerchauTest.Application.Customers.QueryHandlers
{
	public class GetCustomerByIdQueryHandler : IQueryHandler<GetCustomerByIdQuery, CustomerDto?>
	{
		private readonly FerchauDbContext _dbContext;
		public GetCustomerByIdQueryHandler(FerchauDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<CustomerDto?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
		{
			var customer = await _dbContext.Customers
				.Where(s => s.Id == request.CustomerId)
				.Select(s => new CustomerDto(s.Id, s.Firstname.Value, s.Lastname.Value, s.PhoneNumber.Value))
				.SingleOrDefaultAsync();

			return customer;
		}
	}
}
