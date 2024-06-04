using FerchauTest.Domain.Customers;
using FerchauTest.Shared.Shared;
using Moq;

namespace FerchauTest.Domain.Tests.Customers
{
	internal class CustomerBuilder
	{
		internal Mock<IIdGenerator> _idgenerator;
		internal string _firstname;
		internal string _lastname;
		internal string _phonenumber;

		internal static CustomerBuilder Instance
		{
			get
			{
				var result = new CustomerBuilder();

				return result;
			}
		}
		public CustomerBuilder()
		{
			WithFirstname("Ali Akbar");
			WithLastname("Jahan bin");
			WithPhoneNumber("+989121234567");

			_idgenerator = new Mock<IIdGenerator>();
			SetIdGenerator(999);
		}
		internal CustomerBuilder WithFirstname(string firstname) { _firstname = firstname; return this; }
		internal CustomerBuilder WithLastname(string lastname) { _lastname = lastname; return this; }
		internal CustomerBuilder WithPhoneNumber(string phoneNumber) { _phonenumber = phoneNumber; return this; }
		internal CustomerBuilder SetIdGenerator(long id)
		{
			_idgenerator.Setup(s => s.GetNewId()).Returns(id);

			return this;
		}
		internal Customer Create()
		{
			return Customer.Create(_firstname, _lastname, _phonenumber, _idgenerator.Object);
		}
	}
}
