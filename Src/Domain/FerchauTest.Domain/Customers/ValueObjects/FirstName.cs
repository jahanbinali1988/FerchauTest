using FerchauTest.Domain.Customers.Constants;
using FerchauTest.Domain.Customers.Exceptions;
using FerchauTest.Shared.SeedWork;

namespace FerchauTest.Domain.Customers.ValueObjects
{
	public class FirstName : ValueObject
	{
		public static implicit operator FirstName(string? value)
		{
			if (string.IsNullOrEmpty(value))
				return null;

			return new FirstName(value: value);
		}

		private FirstName() : base()
		{
		}
		private FirstName(string value) : this()
		{
			Value = value;
			Validate();
		}

		public string Value { get; init; }

		private void Validate()
		{
			if (Value.Length > ConstantValues.MaximumFirstnameLength)
				throw new FirstNameLengthIsLongerThanLimitationException(Value);
		}
	}
}
