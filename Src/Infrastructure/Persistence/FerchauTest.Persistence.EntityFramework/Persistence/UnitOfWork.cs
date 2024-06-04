using FerchauTest.Shared.EventProcessing.DomainEvent;
using FerchauTest.Shared.SeedWork;

namespace FerchauTest.Persistence.EntityFramework.Persistence
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly FerchauDbContext _dbContext;
		private readonly IDomainEventsDispatcher _domainEventsDispatcher;
		public UnitOfWork(FerchauDbContext dbContext,
			IDomainEventsDispatcher domainEventsDispatcher)
		{
			_dbContext = dbContext;
			_domainEventsDispatcher = domainEventsDispatcher;
		}

		public async Task<int> CommitAsync(CancellationToken cancellationToken)
		{
			using (var transaction = await _dbContext.Database.BeginTransactionAsync(CancellationToken.None))
			{
				try
				{
					await _domainEventsDispatcher.DispatchEventsAsync();
					var result = await _dbContext.SaveChangesAsync(cancellationToken);

					//ignore cancellation token
					await transaction.CommitAsync(CancellationToken.None);
					return result;
				}
				catch (Exception)
				{
					await transaction.RollbackAsync(CancellationToken.None);
					throw;
				}
			}
		}
	}
}
