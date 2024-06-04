using FerchauTest.Shared.Application;

namespace FerchauTest.Application.Contract.Cars.Commands
{
	public class CreateContractCommand : CommandBase
	{

		public CreateContractCommand(long carId, long customerId, DateTimeOffset startDate, DateTimeOffset endDate)
		{
			CarId = carId;
			CustomerId = customerId;
			StartDate = startDate;
			EndDate = endDate;
		}

		public long CarId { get; set; }
		public long CustomerId { get; set; }
		public DateTimeOffset StartDate { get; set; }
		public DateTimeOffset EndDate { get; set; }
	}
}
