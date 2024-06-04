using FerchauTest.Domain.Cars;
using FerchauTest.Domain.Cars.Entities;
using FerchauTest.Domain.Cars.ValueObjects;
using FerchauTest.Domain.Customers.DomainServices;
using FerchauTest.Domain.Tests.Customers;
using FerchauTest.Shared.Shared;
using Moq;

namespace FerchauTest.Domain.Tests.Cars
{
	internal class ContractBuilder
	{
		internal Mock<IIdGenerator> _idgenerator;
		internal Mock<ICustomerExistenceService> _customerExistenceService;
		internal DateTimeOffset _startDate;
		internal DateTimeOffset _endDate;
		internal bool _isFinished;
		internal int _usedKilometers;
		public long _customerId;
		public long _carId;

		internal static ContractBuilder Instance
		{
			get
			{
				var result = new ContractBuilder();

				return result;
			}
		}

		public ContractBuilder()
		{
			WithStartDate(DateTimeOffset.Now.AddDays(-1));
			WithEndDate(DateTimeOffset.Now.AddDays(1));
			WithUsedKilometers(200);
			WithIsFinished(false);
			WithCustomerId(100);
			WithCarId(100);

			_idgenerator = new Mock<IIdGenerator>();
			SetIdGenerator(999);

			_customerExistenceService = new Mock<ICustomerExistenceService>();
			SetCustomerExistenceService(true);
		}
		internal ContractBuilder WithStartDate(DateTimeOffset startDate) { _startDate = startDate; return this; }
		internal ContractBuilder WithEndDate(DateTimeOffset endDate) { _endDate = endDate; return this; }
		internal ContractBuilder WithUsedKilometers(int usedKilometer) { _usedKilometers = usedKilometer; return this; }
		internal ContractBuilder WithIsFinished(bool isFinished) { _isFinished = isFinished; return this; }
		internal ContractBuilder WithCustomerId(long customerId) { _customerId = customerId; return this; }
		internal ContractBuilder WithCarId(long carId) { _carId = carId; return this; }
		internal ContractBuilder SetIdGenerator(long id)
		{
			_idgenerator.Setup(s => s.GetNewId()).Returns(id);

			return this;
		}
		internal ContractBuilder SetCustomerExistenceService(bool result)
		{
			_customerExistenceService.Setup(s => s.IsExistedAsync(It.IsAny<long>())).ReturnsAsync(result);

			return this;
		}

		internal Task<Contract> CreateAsync()
		{
			return Contract.CreateAsync(_customerId, _carId, _startDate, _endDate, _idgenerator.Object, _customerExistenceService.Object);
		}
	}
}
