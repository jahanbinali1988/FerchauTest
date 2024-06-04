using FerchauTest.Shared.SeedWork;
using FerchauTest.Domain.Cars.Entities;
using FerchauTest.Shared.Shared;
using FerchauTest.Domain.Customers.DomainServices;
using FerchauTest.Domain.Cars.Exceptions;
using FerchauTest.Domain.Cars.ValueObjects;

namespace FerchauTest.Domain.Cars
{
	public class Car : Entity<long>, IAggregateRoot
	{
        private Car() : base()
        {
            Contracts = new List<Contract>();
        }
        private Car(string brand, string model, IIdGenerator idGenerator) : this()
        {
            SetId(idGenerator);
            SetBrand(brand);
            SetModel(model);
        }

        public Brand Brand { get; private set; }
        public Model Model { get; private set; }
        public int TotalKilometres { get; private set; }

        public List<Contract> Contracts { get; private set; }

        #region PrivateMethods
        private void SetId(IIdGenerator idGenerator) => base.Id = idGenerator.GetNewId();
        private void SetBrand(string brand) => Brand = brand;
        private void SetModel(string model) => Model = model;
        private void SetTotalKilometers(int kilometers) => TotalKilometres = kilometers;
		#endregion

		#region PublicMethods
		public static Car Create(string brand, string model, IIdGenerator idGenerator)
        {
            return new Car(brand, model, idGenerator);
        }

		public void Delete()
        {
            if (Contracts.Any(a => !a.IsFinished))
                throw new CarHasUnfinishedContractException();

            base.MarkAsDeleted();
        }
        public void Update(string brand, string model)
		{
			SetBrand(brand);
			SetModel(model);
            base.MarkAsUpdated();
		}
        public async Task AssignContractAsync(long customerId, long carId, DateTimeOffset startDate, DateTimeOffset endDate, IIdGenerator idGenerator, ICustomerExistenceService customerExistenceService)
        {
            if (Contracts.Any(a => !a.IsFinished))
                throw new CarHasUnfinishedContractException();

            var contract = await Contract.CreateAsync(customerId, carId, startDate, endDate, idGenerator, customerExistenceService);

            Contracts.Add(contract);
			base.MarkAsUpdated();
		}
        public void FinishContract(long contractId, int usedKilometer)
        {
            var contract = Contracts.FirstOrDefault(c=> c.Id == contractId);
            if (contract == null)
                throw new ContractIsNotExistedException(contractId.ToString());

            contract.Finish(usedKilometer);
            SetTotalKilometers(usedKilometer);
			base.MarkAsUpdated();
		}
        #endregion
    }
}
