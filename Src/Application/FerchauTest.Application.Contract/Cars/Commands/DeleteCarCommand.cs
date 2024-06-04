using FerchauTest.Shared.Application;

namespace FerchauTest.Application.Contract.Cars.Commands
{
	public class DeleteCarCommand : CommandBase
	{
		public long CarId { get; set; }

		public DeleteCarCommand(long carId)
		{
			CarId = carId;
		}
	}
}
