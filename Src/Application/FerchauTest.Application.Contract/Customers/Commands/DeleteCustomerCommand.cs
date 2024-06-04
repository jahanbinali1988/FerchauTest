using FerchauTest.Shared.Application;

namespace FerchauTest.Application.Contract.Customers.Commands
{
	public class DeleteCustomerCommand : CommandBase
	{
		public long CustomerId { get; set; }

		public DeleteCustomerCommand(long customerId)
		{
			CustomerId = customerId;
		}
	}
}
