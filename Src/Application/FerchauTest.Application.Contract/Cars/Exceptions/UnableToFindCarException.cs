using FerchauTest.Shared.Exceptions;
using FerchauTest.Shared.SeedWork;

namespace FerchauTest.Application.Contract.Cars.Exceptions
{
	public class UnableToFindCarException : BusinessException
	{
		public UnableToFindCarException(string message)
			: base(ExceptionsEnum.UnableToFindCarException, $"Unable to find customer with the given id {message}")
		{
		}
	}
}
