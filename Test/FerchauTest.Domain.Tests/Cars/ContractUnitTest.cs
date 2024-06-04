using FerchauTest.Domain.Cars.Exceptions;
using Shouldly;

namespace FerchauTest.Domain.Tests.Cars
{
	public class ContractUnitTest
	{
		[Fact]
		public async Task Create_contract_successfully()
		{
			var expectedId = 1;
			var expectedCustomerId = 1;
			var expectedCarId = 1;
			var expectedStartDate = DateTimeOffset.Now.AddDays(-2);
			var expectedEndDate = DateTimeOffset.Now.AddDays(2);
			var builder = ContractBuilder.Instance
				.SetIdGenerator(expectedId)
				.WithCustomerId(expectedCustomerId)
				.WithCarId(expectedCarId)
				.WithStartDate(expectedStartDate)
				.WithEndDate(expectedEndDate)
				.SetCustomerExistenceService(true);

			var contract = await builder.CreateAsync();

			contract.Id.ShouldBe(expectedId);
			contract.CustomerId.ShouldBe(expectedCustomerId);
			contract.CarId.ShouldBe(expectedCarId);
			contract.StartDate.ShouldBe(expectedStartDate);
			contract.EndDate.ShouldBe(expectedEndDate);
			contract.UsedKilometers.ShouldBe(0);
			contract.IsFinished.ShouldBe(false);
		}

		[Fact]
		public async Task Unable_to_create_contract_successfully_when_customer_is_not_existed()
		{
			var builder = ContractBuilder.Instance
				.SetCustomerExistenceService(false);

			await Assert.ThrowsAsync<CustomerIdDoesNotExistException>(()=> builder.CreateAsync());
		}

		[Fact]
		public async Task Unable_to_create_contract_successfully_when_customer_id_value_is_default()
		{
			var builder = ContractBuilder.Instance
				.WithCustomerId(default);

			await Assert.ThrowsAsync<InvalidCorelationIdValueException>(() => builder.CreateAsync());
		}

		[Fact]
		public async Task Unable_to_create_contract_successfully_when_car_id_value_is_default()
		{
			var builder = ContractBuilder.Instance
				.WithCarId(default);

			await Assert.ThrowsAsync<InvalidCorelationIdValueException>(() => builder.CreateAsync());
		}

		[Fact]
		public async Task Finish_contract_successfully()
		{
			var expectedKilimeters = 10;
			var builder = ContractBuilder.Instance;

			var contract = await builder.CreateAsync();
			contract.Finish(expectedKilimeters);

			contract.UsedKilometers.ShouldBe(expectedKilimeters);
			contract.IsFinished.ShouldBeTrue();
		}
	}
}
