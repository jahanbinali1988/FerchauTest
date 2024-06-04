using FerchauTest.Domain.Customers.Constants;
using FerchauTest.Domain.Customers.Exceptions;
using FerchauTest.Shared.SeedWork;

namespace FerchauTest.Domain.Customers.ValueObjects
{
	public class PhoneNumber : ValueObject
	{
		public static implicit operator PhoneNumber(string? value)
		{
			if (string.IsNullOrEmpty(value))
				return null;

			return new PhoneNumber(value: value);
		}

		private PhoneNumber() : base()
		{
		}
		private PhoneNumber(string value) : this()
		{
			Value = value;
			Validate();
		}

		public string Value { get; init; }

		private void Validate()
		{
			if (Value.Length > ConstantValues.MaximumPhoneNumberLength)
				throw new PhoneNumberLengthIsLongerThanLimitationException(Value);
		}
	}
}
