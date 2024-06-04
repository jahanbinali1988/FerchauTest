using FerchauTest.Shared.Exceptions;
using FerchauTest.Shared.SeedWork;

namespace FerchauTest.Domain.Cars.Exceptions
{
	public class CarHasUnfinishedContractException : BusinessException
	{
		public CarHasUnfinishedContractException()
	: base(code: ExceptionsEnum.CarHasUnfinishedContractException,
		  message: $"Specified car has unfinished contract yet!")
		{
		}
	}
}
