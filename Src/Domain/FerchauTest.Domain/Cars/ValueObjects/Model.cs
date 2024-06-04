using FerchauTest.Domain.Cars.Constants;
using FerchauTest.Domain.Customers.Exceptions;
using FerchauTest.Shared.SeedWork;

namespace FerchauTest.Domain.Cars.ValueObjects
{
	public class Model : ValueObject
	{
		public static implicit operator Model(string? value)
		{
			if (string.IsNullOrEmpty(value))
				return null;

			return new Model(value: value);
		}

		private Model() : base()
		{
		}
		private Model(string value) : this()
		{
			Value = value;
			Validate();
		}

		public string Value { get; init; }

		private void Validate()
		{
			if (Value.Length > ConstantValues.MaximumModelLength)
				throw new ModelLengthIsLongerThanLimitationException(Value);
		}

	}
}
