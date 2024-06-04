using FerchauTest.Shared.Exceptions;
using FerchauTest.Shared.SeedWork;

namespace FerchauTest.Domain.Customers.Exceptions
{
	public class LastNameLengthIsLongerThanLimitationException : BusinessException
	{
		public LastNameLengthIsLongerThanLimitationException(string lastname)
			: base(code: ExceptionsEnum.LastNameLengthIsLongerThanLimitationException,
				  message: $"The given value {lastname} is longger than expected")
		{
		}
	}
}
