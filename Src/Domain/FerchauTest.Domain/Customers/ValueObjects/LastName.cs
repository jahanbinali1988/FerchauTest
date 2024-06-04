using FerchauTest.Domain.Customers.Constants;
using FerchauTest.Domain.Customers.Exceptions;
using FerchauTest.Shared.SeedWork;

namespace FerchauTest.Domain.Customers.ValueObjects
{
	public class LastName : ValueObject
	{
		public static implicit operator LastName(string? value)
		{
			if (string.IsNullOrEmpty(value))
				return null;

			return new LastName(value: value);
		}

		private LastName() : base()
		{
		}
		private LastName(string value) : this()
		{
			Value = value;
			Validate();
		}

		public string Value { get; init; }

		private void Validate()
		{
			if (Value.Length > ConstantValues.MaximumLastnameLength)
				throw new LastNameLengthIsLongerThanLimitationException(Value);
		}
	}
}
