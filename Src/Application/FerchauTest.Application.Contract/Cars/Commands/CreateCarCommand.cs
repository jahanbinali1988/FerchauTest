using FerchauTest.Shared.Application;

namespace FerchauTest.Application.Contract.Cars.Commands
{
	public class CreateCarCommand : CommandBase<long>
	{
		public CreateCarCommand(string brand, string model)
		{
			Brand = brand;
			Model = model;
		}
		public string Brand { get; set; }
		public string Model { get; set; }
	}
}
