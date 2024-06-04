using FerchauTest.Domain.Cars.Exceptions;
using FerchauTest.Domain.Cars.ValueObjects;
using FerchauTest.Domain.Customers;
using FerchauTest.Domain.Customers.DomainServices;
using FerchauTest.Shared.SeedWork;
using FerchauTest.Shared.Shared;

namespace FerchauTest.Domain.Cars.Entities
{
    public class Contract : Entity<long>
    {
        private Contract() : base()
        {
            
        }
        private Contract(long customerId, long carId, DateTimeOffset startDate, DateTimeOffset endDate, IIdGenerator idGenerator) : this()
		{
			SetId(idGenerator);
			SetCustomerId(customerId);
			SetCarId(carId);
			SetStartDate(startDate);
			SetEndDate(endDate);
			SetIsFinished(false);
		}

        public DateTimeOffset StartDate { get; private set; }
		public DateTimeOffset EndDate { get; private set; }
		public bool IsFinished { get; private set; }
		public int UsedKilometers { get; private set; }

		public CorelationId CustomerId { get; private set; }
		public Customer Customer { get; private set; }
		public CorelationId CarId { get; private set; }
		public Car Car { get; private set; }

		#region PrivateMethods
		private void SetId(IIdGenerator idGenerator) => base.Id = idGenerator.GetNewId();
		private void SetCustomerId(long customerId)
		{ 
			CustomerId = customerId;
		}
		private void SetCarId(long carId) => CarId = carId;
		private void SetStartDate(DateTimeOffset startDate) => StartDate = startDate;
		private void SetEndDate(DateTimeOffset endDate) => EndDate = endDate;
		private void SetIsFinished(bool isFinished) => IsFinished = isFinished;
		private void SetUsedKilometers(int usedKilometers) => UsedKilometers = usedKilometers;
		#endregion

		#region PublicMethods
		public static async Task<Contract> CreateAsync(long customerId, long carId, DateTimeOffset startDate, DateTimeOffset endDate, IIdGenerator idGenerator, ICustomerExistenceService customerExistenceService)
		{
			var isCustomerExisted = await customerExistenceService.IsExistedAsync(customerId);
			if (!isCustomerExisted)
				throw new CustomerIdDoesNotExistException(customerId.ToString());

			return new Contract(customerId, carId, startDate, endDate, idGenerator);
		}
		public void Finish(int usedKilometer)
		{
			SetUsedKilometers(usedKilometer);
			SetIsFinished(true);
		}
		#endregion
	}
}
