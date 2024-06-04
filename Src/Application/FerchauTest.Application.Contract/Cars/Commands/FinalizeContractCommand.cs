using FerchauTest.Shared.Application;

namespace FerchauTest.Application.Contract.Cars.Commands
{
	public class FinalizeContractCommand : CommandBase
	{
		public FinalizeContractCommand(long carId, long contractId, int usedKilometers)
		{
			CarId = carId;
			ContractId = contractId;
			UsedKilometers = usedKilometers;
		}

		public long CarId { get; set; }
		public long ContractId { get; set; }
		public int UsedKilometers { get; set; }
	}
}
