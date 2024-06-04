using FerchauTest.Persistence.EntityFramework.Persistence;
using FerchauTest.Shared.EventProcessing.DomainEvent;
using FerchauTest.Shared.SeedWork;
using MediatR;

namespace FerchauTest.Persistence.EntityFramework.EventProcessing
{
	public class DomainEventsDispatcher : IDomainEventsDispatcher
	{
		private readonly IMediator _mediator;
		private readonly FerchauDbContext _dbContext;

		public DomainEventsDispatcher(IMediator mediator, FerchauDbContext dbContext)
		{
			_mediator = mediator;
			_dbContext = dbContext;
		}

		public async Task DispatchEventsAsync()
		{
			var domainEntities = _dbContext.ChangeTracker
				.Entries<Entity<long>>()
				.Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList();

			var domainEvents = domainEntities
				.SelectMany(x => x.Entity.DomainEvents)
				.ToList();

			var tasks = domainEvents.Select(e => _mediator.Publish(e));

			await Task.WhenAll(tasks);
		}
	}
}
