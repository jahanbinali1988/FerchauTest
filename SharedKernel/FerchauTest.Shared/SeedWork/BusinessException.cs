using FerchauTest.Shared.Exceptions;

namespace FerchauTest.Shared.SeedWork
{
	public abstract class BusinessException : Exception
	{
		public BusinessException(ExceptionsEnum code, string message)
		{
			Code = code;
			Message = message;
		}
		public ExceptionsEnum Code { get; private set; }
		public string Message { get; private set; }
	}
}
