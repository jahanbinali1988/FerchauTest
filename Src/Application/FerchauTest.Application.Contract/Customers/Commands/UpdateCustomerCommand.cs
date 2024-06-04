using FerchauTest.Shared.Application;

namespace FerchauTest.Application.Contract.Customers.Commands
{
	public class UpdateCustomerCommand : CommandBase<long>
	{
		public UpdateCustomerCommand(long id, string firstName, string lastName, string phoneNumber)
		{
			Id = id;
			FirstName = firstName;
			LastName = lastName;
			PhoneNumber = phoneNumber;
		}
		public long Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
	}
}
