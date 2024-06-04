using FerchauTest.Shared.Application;

namespace FerchauTest.Application.Contract.Customers.Commands
{
	public class CreateCustomerCommand : CommandBase<long>
	{
		public CreateCustomerCommand(string firstName, string lastName, string phoneNumber)
		{
			FirstName = firstName;
			LastName = lastName;
			PhoneNumber = phoneNumber;
		}
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
	}
}
