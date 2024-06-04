using FerchauTest.Domain.Cars.Constants;
using FerchauTest.Domain.Customers.Exceptions;
using FerchauTest.Domain.Customers.ValueObjects;
using FerchauTest.Shared.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerchauTest.Domain.Cars.ValueObjects
{
	public class Brand : ValueObject
	{
		public static implicit operator Brand(string? value)
		{
			if (string.IsNullOrEmpty(value))
				return null;

			return new Brand(value: value);
		}

		private Brand() : base()
		{
		}
		private Brand(string value) : this()
		{
			Value = value;
			Validate();
		}

		public string Value { get; init; }

		private void Validate()
		{
			if (Value.Length > ConstantValues.MaximumBrandLength)
				throw new BrandLengthIsLongerThanLimitationException(Value);
		}
	}
}
