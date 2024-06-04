using FerchauTest.Shared.Exceptions;
using FerchauTest.Shared.SeedWork;

namespace FerchauTest.Domain.Cars.Exceptions
{
	public class InvalidCorelationIdValueException : BusinessException
	{
		public InvalidCorelationIdValueException(string value)
			: base(code: ExceptionsEnum.FirstNameLengthIsLongerThanLimitationException,
				  message: $"The given value {value} is not valid")
		{
		}
	}
}
