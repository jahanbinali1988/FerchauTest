using FerchauTest.Domain.Cars.Constants;
using FerchauTest.Domain.Cars.Exceptions;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerchauTest.Domain.Tests.Cars
{
	public class CarUnitTest
	{
		#region CreateMethod
		[Fact]
		public void Create_car_successfully()
		{
			var expectedId = 1;
			var expectedBrand = "BMW";
			var expectedModel = "I8";
			var builder = CarBuilder.Instance
				.WithBrand(expectedBrand)
				.WithModel(expectedModel)
				.SetIdGenerator(expectedId);

			var car = builder.Create();

			car.Id.ShouldBe(expectedId);
			car.Model.ShouldBe(expectedModel);
			car.Brand.ShouldBe(expectedBrand);
			car.TotalKilometres.ShouldBe(0);
		}

		[Fact]
		public void Unable_to_create_car_successfully_with_brand_more_than_defined_firstname_character_length()
		{
			var expectedBrand = new string('*', ConstantValues.MaximumBrandLength + 1);
			var builder = CarBuilder.Instance
				.WithBrand(expectedBrand);

			Assert.Throws< BrandLengthIsLongerThanLimitationException>(() => builder.Create());
		}

		[Fact]
		public void Unable_to_create_car_successfully_with_model_more_than_defined_firstname_character_length()
		{
			var expectedModel = new string('*', ConstantValues.MaximumModelLength + 1);
			var builder = CarBuilder.Instance
				.WithModel(expectedModel);

			Assert.Throws<ModelLengthIsLongerThanLimitationException>(() => builder.Create());
		}
		#endregion

		#region Delete
		[Fact]
		public void Delete_car_successfully()
		{
			var builder = CarBuilder.Instance;
			var car = builder.Create();

			car.Delete();

			car.IsDeleted.ShouldBe(true);
		}
		[Fact]
		public async Task Unable_to_delete_car_successfully_when_it_has_active_contract()
		{
			var carBuilder = CarBuilder.Instance;
			var contactBuilder = ContractBuilder.Instance;
			var car = carBuilder.Create();
			await car.AssignContractAsync(contactBuilder._customerId,
				contactBuilder._carId,
				contactBuilder._startDate,
				contactBuilder._endDate,
				contactBuilder._idgenerator.Object,
				contactBuilder._customerExistenceService.Object);

			Assert.ThrowsAny<CarHasUnfinishedContractException>(() => car.Delete());
		}
		#endregion

		#region AssignContract
		[Fact]
		public async Task Assign_contract_to_car_successfully()
		{
			var carBuilder = CarBuilder.Instance;
			var contactBuilder = ContractBuilder.Instance;
			var car = carBuilder.Create();

			await car.AssignContractAsync(contactBuilder._customerId,
				contactBuilder._carId,
				contactBuilder._startDate,
				contactBuilder._endDate,
				contactBuilder._idgenerator.Object,
				contactBuilder._customerExistenceService.Object);
			
			car.Contracts.ShouldNotBeEmpty();
			car.Contracts.ToList().Count.ShouldBe(1);
		}
		[Fact]
		public async Task Unable_to_assign_contract_to_car_when_it_has_an_active_contract()
		{
			var carBuilder = CarBuilder.Instance;
			var contactBuilder = ContractBuilder.Instance;
			var car = carBuilder.Create();

			await car.AssignContractAsync(contactBuilder._customerId,
				contactBuilder._carId,
				contactBuilder._startDate,
				contactBuilder._endDate,
				contactBuilder._idgenerator.Object,
				contactBuilder._customerExistenceService.Object);

			await Assert.ThrowsAsync<CarHasUnfinishedContractException>(() => car.AssignContractAsync(contactBuilder._customerId,
				contactBuilder._carId,
				contactBuilder._startDate,
				contactBuilder._endDate,
				contactBuilder._idgenerator.Object,
				contactBuilder._customerExistenceService.Object));

		}
		#endregion

		#region Update
		[Fact]
		public void Update_car_successfully()
		{
			var ActualBrand = "BMW";
			var ActualModel = "I8";
			var ActualId = 1;
			var expectedBrand = "Benz";
			var expectedModel = "S500";
			var builder = CarBuilder.Instance
				.WithBrand(ActualBrand)
				.WithModel(ActualModel)
				.SetIdGenerator(ActualId);
			var car = builder.Create();

			car.Update(expectedBrand, expectedModel);

			car.Model.ShouldBe(expectedModel);
			car.Brand.ShouldBe(expectedBrand);
			car.TotalKilometres.ShouldBe(0);
		}
		[Fact]
		public void Unable_to_update_car_successfully_with_brand_more_than_defined_firstname_character_length()
		{
			var expectedBrand = new string('*', ConstantValues.MaximumBrandLength + 1);
			var builder = CarBuilder.Instance;
			var car = builder.Create();

			Assert.Throws<BrandLengthIsLongerThanLimitationException>(() => car.Update(expectedBrand, builder._model));
		}
		[Fact]
		public void Unable_to_update_car_successfully_with_model_more_than_defined_firstname_character_length()
		{
			var expectedModel = new string('*', ConstantValues.MaximumModelLength  + 1);
			var builder = CarBuilder.Instance;
			var car = builder.Create();

			Assert.Throws<ModelLengthIsLongerThanLimitationException>(() => car.Update(builder._brand, expectedModel));
		}
		#endregion

		#region FinishContract
		[Fact]
		public async Task Finish_contract_successfully()
		{
			var actualContractId = 1;
			var expectedUsedKilometer = 10;
			var carBuilder = CarBuilder.Instance;
			var contractBuilder = ContractBuilder.Instance.SetIdGenerator(actualContractId);
			var car = carBuilder.Create();
			await car.AssignContractAsync(contractBuilder._customerId,
				contractBuilder._carId,
				contractBuilder._startDate,
				contractBuilder._endDate,
				contractBuilder._idgenerator.Object,
				contractBuilder._customerExistenceService.Object);

			car.FinishContract(actualContractId, expectedUsedKilometer);

			car.Contracts.FirstOrDefault(c => c.Id == actualContractId).ShouldNotBeNull();
			car.Contracts.First(c => c.Id == actualContractId).IsFinished.ShouldBeTrue();
			car.TotalKilometres.ShouldBe(expectedUsedKilometer);
			car.Contracts.First(c => c.Id == actualContractId).UsedKilometers.ShouldBe(expectedUsedKilometer);
		}
		[Fact]
		public async Task Unable_to_finish_contract_when_contractId_is_invalid()
		{
			var actualContractId = 1;
			var expectedContractId = 2;
			var expectedUsedKilometer = 10;
			var carBuilder = CarBuilder.Instance;
			var contractBuilder = ContractBuilder.Instance.SetIdGenerator(actualContractId);
			var car = carBuilder.Create();
			await car.AssignContractAsync(contractBuilder._customerId,
				contractBuilder._carId,
				contractBuilder._startDate,
				contractBuilder._endDate,
				contractBuilder._idgenerator.Object,
				contractBuilder._customerExistenceService.Object);

			Assert.Throws<ContractIsNotExistedException>(()=> car.FinishContract(expectedContractId, expectedUsedKilometer));
		}
		#endregion
	}
}
