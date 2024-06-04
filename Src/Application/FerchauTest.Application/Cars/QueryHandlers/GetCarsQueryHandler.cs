using FerchauTest.Application.Contract.Cars.Dtos;
using FerchauTest.Application.Contract.Cars.Queries;
using FerchauTest.Persistence.EntityFramework.Persistence;
using FerchauTest.Shared.Application;
using Microsoft.EntityFrameworkCore;

namespace FerchauTest.Application.Cars.QueryHandlers
{
	internal class GetCarsQueryHandler : IQueryHandler<GetCarsQuery, Pagination<CarDto>>
	{
		private readonly FerchauDbContext _dbContext;
		public GetCarsQueryHandler(FerchauDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<Pagination<CarDto>> Handle(GetCarsQuery request, CancellationToken cancellationToken)
		{
			var totalCount = await _dbContext.Cars.CountAsync();
			var cars = await _dbContext.Cars
				.Select(s => new CarDto(s.Id, s.Brand.Value, s.Model.Value))
				.ToListAsync();

			return new Pagination<CarDto>() { Items = cars, TotalItems = totalCount };
		}
	}
}
