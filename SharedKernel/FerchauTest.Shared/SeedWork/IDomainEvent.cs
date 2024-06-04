using System;
using MediatR;

namespace FerchauTest.Shared.SeedWork
{
	public interface IDomainEvent : INotification
	{
		DateTimeOffset OccurredOn { get; }
	}
}
