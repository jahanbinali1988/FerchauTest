using FerchauTest.Shared.Exceptions;
using FerchauTest.Shared.SeedWork;

namespace FerchauTest.Domain.Cars.Exceptions
{
	public class ModelLengthIsLongerThanLimitationException : BusinessException
	{
		public ModelLengthIsLongerThanLimitationException(string firstname)
			: base(code: ExceptionsEnum.ModelLengthIsLongerThanLimitationException,
				  message: $"The given value {firstname} is longger than expected")
		{
		}
	}
}
