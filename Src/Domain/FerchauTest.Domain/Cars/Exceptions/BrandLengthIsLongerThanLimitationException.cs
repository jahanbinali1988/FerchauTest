using FerchauTest.Shared.Exceptions;
using FerchauTest.Shared.SeedWork;

namespace FerchauTest.Domain.Customers.Exceptions
{
	public class BrandLengthIsLongerThanLimitationException : BusinessException
	{
		public BrandLengthIsLongerThanLimitationException(string lastname)
			: base(code: ExceptionsEnum.BrandLengthIsLongerThanLimitationException,
				  message: $"The given value {lastname} is longger than expected")
		{
		}
	}
}
