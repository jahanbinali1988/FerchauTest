using FerchauTest.Shared.Exceptions;
using FerchauTest.Shared.SeedWork;

namespace FerchauTest.Domain.Customers.Exceptions
{
	public class PhoneNumberLengthIsLongerThanLimitationException : BusinessException
	{
		public PhoneNumberLengthIsLongerThanLimitationException(string phoneNumberValue)
			: base(code: ExceptionsEnum.PhoneNumberLengthIsLongerThanLimitationException,
				  message: $"The given value {phoneNumberValue} is longger than expected")
		{
		}
	}
}
