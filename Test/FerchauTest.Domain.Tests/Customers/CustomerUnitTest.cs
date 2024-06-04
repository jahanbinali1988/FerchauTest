using FerchauTest.Domain.Customers.Constants;
using FerchauTest.Domain.Customers.Exceptions;
using Shouldly;

namespace FerchauTest.Domain.Tests.Customers
{
    public class CustomerUnitTest
    {
		#region Create
		[Fact]
		public void Create_Customer_Successfully()
		{
			var expectedId = 1;
			var expectedFirstname = "Ali";
			var expectedLastName = "Jahanbin";
			var expectedPhonenumber = "+436605252544";
			var builder = CustomerBuilder.Instance
				.WithFirstname(expectedFirstname)
				.WithLastname(expectedLastName)
				.WithPhoneNumber(expectedPhonenumber)
				.SetIdGenerator(expectedId);

			var customer = builder.Create();

			customer.Id.ShouldBe(expectedId);
			customer.Firstname.Value.ShouldBe(expectedFirstname);
			customer.Lastname.Value.ShouldBe(expectedLastName);
			customer.PhoneNumber.Value.ShouldBe(expectedPhonenumber);
		}
		[Fact]
		public void Unable_to_create_Customer_with_firstname_more_than_defined_firstname_character_length()
		{
			var expectedFirstname = new string('A', ConstantValues.MaximumFirstnameLength + 1);
			var builder = CustomerBuilder.Instance
				.WithFirstname(expectedFirstname);

			Assert.Throws<FirstNameLengthIsLongerThanLimitationException>(() => builder.Create());
		}
		[Fact]
		public void Unable_to_create_Customer_with_lastname_more_than_defined_character_length()
		{
			var expectedLastname = new string('A', ConstantValues.MaximumLastnameLength + 1);
			var builder = CustomerBuilder.Instance
				.WithLastname(expectedLastname);

			Assert.Throws<LastNameLengthIsLongerThanLimitationException>(() => builder.Create());
		}
		[Fact]
		public void Unable_to_create_Customer_with_phonenumber_more_than_defined_character_length()
		{
			var expectedPhonenumber = new string('1', ConstantValues.MaximumPhoneNumberLength + 1);
			var builder = CustomerBuilder.Instance
				.WithPhoneNumber(expectedPhonenumber);

			Assert.Throws<PhoneNumberLengthIsLongerThanLimitationException>(() => builder.Create());
		}
		#endregion
	}
}