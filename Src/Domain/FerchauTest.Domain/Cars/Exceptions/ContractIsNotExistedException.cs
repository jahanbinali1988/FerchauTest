using FerchauTest.Shared.Exceptions;
using FerchauTest.Shared.SeedWork;

namespace FerchauTest.Domain.Cars.Exceptions
{
	public class ContractIsNotExistedException : BusinessException
	{
		public ContractIsNotExistedException(string value)
			: base(code: ExceptionsEnum.ContractIsNotExistedException,
				  message: $"The given contract id {value} is not existed")
		{
		}
	}
}
