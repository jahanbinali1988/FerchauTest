using FerchauTest.Application.Contract.Cars.Dtos;
using FerchauTest.Application.Contract.Cars.Queries;
using FerchauTest.Persistence.EntityFramework.Persistence;
using FerchauTest.Shared.Application;
using Microsoft.EntityFrameworkCore;

namespace FerchauTest.Application.Cars.QueryHandlers
{
	public class GetCarByIdQueryHandler : IQueryHandler<GetCarByIdQuery, CarDto?>
	{
		private readonly FerchauDbContext _dbContext;
		public GetCarByIdQueryHandler(FerchauDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<CarDto?> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
		{
			var customer = await _dbContext.Cars
				.Where(s => s.Id == request.CarId)
				.Select(s => new CarDto(s.Id, s.Brand.Value, s.Model.Value))
				.SingleOrDefaultAsync();

			return customer;
		}
	}
}
