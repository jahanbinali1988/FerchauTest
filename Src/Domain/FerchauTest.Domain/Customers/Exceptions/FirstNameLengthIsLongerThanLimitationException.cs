using FerchauTest.Shared.Exceptions;
using FerchauTest.Shared.SeedWork;

namespace FerchauTest.Domain.Customers.Exceptions
{
	public class FirstNameLengthIsLongerThanLimitationException : BusinessException
	{
		public FirstNameLengthIsLongerThanLimitationException(string firstname)
			: base(code: ExceptionsEnum.FirstNameLengthIsLongerThanLimitationException,
				  message: $"The given value {firstname} is longger than expected")
		{
		}
	}
}
