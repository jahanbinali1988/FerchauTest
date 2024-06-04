using System.Threading.Tasks;

namespace FerchauTest.Shared.EventProcessing.DomainEvent
{
	public interface IDomainEventsDispatcher
	{
		Task DispatchEventsAsync();
	}
}
