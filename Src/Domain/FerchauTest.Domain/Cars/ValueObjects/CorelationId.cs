using FerchauTest.Domain.Cars.Exceptions;
using FerchauTest.Shared.SeedWork;

namespace FerchauTest.Domain.Cars.ValueObjects
{
	public class CorelationId : ValueObject
	{
		public static implicit operator CorelationId(long value)
		{
			return new CorelationId(value: value!);
		}

		private CorelationId() : base()
		{
		}

		public CorelationId(long value) : this()
		{
			Validate(value);
			Value = value;
		}

		public void Validate(long value)
		{
			if (value == default)
				throw new InvalidCorelationIdValueException(value!.ToString());
		}

		public long Value { get; set; }
	}
}
