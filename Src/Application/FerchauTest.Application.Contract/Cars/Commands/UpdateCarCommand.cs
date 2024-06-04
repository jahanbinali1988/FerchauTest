using FerchauTest.Shared.Application;

namespace FerchauTest.Application.Contract.Cars.Commands
{
	public class UpdateCarCommand : CommandBase<long>
	{
		public UpdateCarCommand(long id, string brand, string model)
		{
			Id = id;
			Brand = brand;
			Model = model;
		}
		public long Id { get; set; }
		public string Brand { get; set; }
		public string Model { get; set; }
	}
}
