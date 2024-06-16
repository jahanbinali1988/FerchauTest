namespace FerchauTest.Application.Contract.Customers.Dtos
{
	public class CustomerDto
	{
		public CustomerDto(long id, string firstname, string lastname, string phoneNumber)
		{
			Id = id;
			FirstName = firstname;
			LastName = lastname;
			PhoneNumber = phoneNumber;
		}
		public long Id { get; init; }
		public string FirstName { get; init; }
		public string LastName { get; init; }
		public string PhoneNumber { get; init; }
	}
}
