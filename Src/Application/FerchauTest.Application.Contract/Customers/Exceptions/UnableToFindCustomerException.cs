using FerchauTest.Shared.Exceptions;
using FerchauTest.Shared.SeedWork;

namespace FerchauTest.Application.Contract.Customers.Exceptions
{
	public class UnableToFindCustomerException : BusinessException
	{
		public UnableToFindCustomerException(string message)
			: base(ExceptionsEnum.UnableToFindCustomerException, $"Unable to find customer with the given id {message}")
		{
		}
	}
}
