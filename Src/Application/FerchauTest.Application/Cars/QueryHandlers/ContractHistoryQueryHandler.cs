using FerchauTest.Application.Contract.Cars.Dtos;
using FerchauTest.Persistence.EntityFramework.Persistence;
using FerchauTest.Shared.Application;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerchauTest.Application.Cars.QueryHandlers
{
	public class ContractHistoryQueryHandler : IQueryHandler<ContractHistoryQuery, ReportDto>
	{
		private readonly FerchauDbContext _dbContext;
		public ContractHistoryQueryHandler(FerchauDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<ReportDto> Handle(ContractHistoryQuery request, CancellationToken cancellationToken)
		{
			var customersHistory = new List<CustomerHistoryDto>();
			var totalRentedCars = await _dbContext.Contracts.CountAsync();

			var customers = await GetCustomersAsync(request.CustomerId, request.PageSize, request.PageCount);

			foreach (var customerId in customers)
			{
				var customer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.Id == customerId);
				if(customer != null)
				{
					var customerHistory = await GetCustomerHistoryAsync(customerId);
					customersHistory.Add(new CustomerHistoryDto()
					{
						Contracts = customerHistory,
						CustomerId = customerId,
						FirstName = customer.Firstname.Value,
						LastName = customer.Lastname.Value
					});
				}
			}

			return new ReportDto()
			{
				TotalRentedCars = totalRentedCars,
				CustomerHistory = customersHistory
			};
		}

		private async Task<List<long>> GetCustomersAsync(long? customerId, int pageSize, int pageCount)
		{
			var query = _dbContext.Contracts
				.Where(c=> customerId == null || c.CustomerId.Value == customerId)
				.GroupBy(s => s.CustomerId.Value)
				.Select(s=> s.Key);

			return await query.Skip((pageCount - 1) * pageSize).Take(pageSize).ToListAsync();
		}
		private async Task<List<CustomerContractHistoryDto>> GetCustomerHistoryAsync(long? customerId)
		{
			var result = await _dbContext.Contracts
				.Where(c => c.CustomerId.Value == customerId)
				.Select(s=> new CustomerContractHistoryDto()
				{
					ContractId = s.CustomerId.Value,
					 Brand = s.Car.Brand.Value,
					 EndDate = s.EndDate,
					 Model = s.Car.Model.Value,
					 StartDate = s.StartDate,
					 CarUsageKilometer = s.Car.TotalKilometres,
					 UsedKilometerDuringContract = s.UsedKilometers
				}).ToListAsync();

			return result;
		}
	}
}
