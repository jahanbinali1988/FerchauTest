using FerchauTest.Application.Contract.Cars.Dtos;
using FerchauTest.Shared.Application;

namespace FerchauTest.Application.Contract.Cars.Queries
{
	public class GetCarByIdQuery : IQuery<CarDto?>
	{
		public GetCarByIdQuery(long carId)
		{
			CarId = carId;
		}
		public long CarId { get; init; }
	}
}
