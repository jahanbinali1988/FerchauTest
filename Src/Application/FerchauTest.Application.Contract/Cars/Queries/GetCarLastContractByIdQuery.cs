using FerchauTest.Application.Contract.Cars.Dtos;
using FerchauTest.Shared.Application;

namespace FerchauTest.Application.Contract.Cars.Queries
{
	public class GetCarLastContractByIdQuery : IQuery<CarLastContractDto?>
	{
		public GetCarLastContractByIdQuery(long carId)
		{
			CarId = carId;
		}
		public long CarId { get; init; }
	}
}
