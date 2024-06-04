using FerchauTest.Shared.Exceptions;
using FerchauTest.Shared.SeedWork;

namespace FerchauTest.Application.Contract.Customers.Exceptions
{
	public class UnableToFindCustomerException : BusinessException
	{
		public UnableToFindCustomerException(ExceptionsEnum code, string message)
			: base(code, $"Unable to find customer with the given id {message}")
		{
		}
	}
}
