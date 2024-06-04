using FerchauTest.Shared.SeedWork;
using System;

namespace FerchauTest.Shared.EventProcessing.DomainEvent
{
	[Serializable]
	public class DomainEventBase : IDomainEvent
	{
		public DomainEventBase()
		{
			OccurredOn = DateTime.Now;
		}

		public DateTimeOffset OccurredOn { get; }
	}
}
