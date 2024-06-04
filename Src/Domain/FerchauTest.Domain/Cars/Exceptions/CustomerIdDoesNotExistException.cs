using FerchauTest.Shared.Exceptions;
using FerchauTest.Shared.SeedWork;

namespace FerchauTest.Domain.Cars.Exceptions
{
	public class CustomerIdDoesNotExistException : BusinessException
	{
		public CustomerIdDoesNotExistException(string value)
			: base(code: ExceptionsEnum.CustomerIdDoesNotExistException,
				  message: $"The given customer id {value} is not existed")
		{
		}
	}
}
