using FerchauTest.Application.Contract.Cars.Dtos;
using FerchauTest.Application.Contract.Cars.Queries;
using FerchauTest.Domain.Cars;
using FerchauTest.Domain.Customers;
using FerchauTest.Persistence.EntityFramework.Persistence;
using FerchauTest.Shared.Application;
using Microsoft.EntityFrameworkCore;

namespace FerchauTest.Application.Cars.QueryHandlers
{
	public class GetCarLastContractByIdQueryHandler : IQueryHandler<GetCarLastContractByIdQuery, CarLastContractDto?>
	{
		private readonly FerchauDbContext _dbContext;
		public GetCarLastContractByIdQueryHandler(FerchauDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<CarLastContractDto?> Handle(GetCarLastContractByIdQuery request, CancellationToken cancellationToken)
		{
			var hasContract = await _dbContext.Contracts.AnyAsync(c => c.CarId.Value == request.CarId);
			if (hasContract)
				return await GetCarInformationWithContractsAsync(request, cancellationToken);
			else
				return await GetCarInformationWithoutContractsAsync(request, cancellationToken);
		}

		public async Task<CarLastContractDto?> GetCarInformationWithContractsAsync(GetCarLastContractByIdQuery request, CancellationToken cancellationToken)
		{
			return await (from contract in _dbContext.Contracts
						  join car in _dbContext.Cars on contract.CarId.Value equals car.Id
						  join customer in _dbContext.Customers on contract.CustomerId.Value equals customer.Id
						  where car.Id == request.CarId
						  orderby contract.StartDate descending
						  select new CarLastContractDto
						  {
							  Id = contract.Id,
							  Brand = car.Brand.Value,
							  CarId = car.Id,
							  EndDate = contract.EndDate,
							  FirstName = customer.Firstname.Value,
							  IsFinished = contract.IsFinished,
							  LastName = customer.Lastname.Value,
							  Model = car.Model.Value,
							  PhoneNumber = customer.PhoneNumber.Value,
							  StartDate = contract.StartDate,
							  UsedKilometers = contract.UsedKilometers
						  }).FirstOrDefaultAsync(cancellationToken);
		}

		public async Task<CarLastContractDto?> GetCarInformationWithoutContractsAsync(GetCarLastContractByIdQuery request, CancellationToken cancellationToken)
		{
			return await _dbContext.Cars.AsNoTracking()
					.Where(c => c.Id == request.CarId)
					.Select(s => new CarLastContractDto()
					{
						Brand = s.Brand.Value,
						Model = s.Model.Value,
						IsFinished = true,
						CarId = s.Id
					}).FirstOrDefaultAsync(cancellationToken);
		}
	}
}
