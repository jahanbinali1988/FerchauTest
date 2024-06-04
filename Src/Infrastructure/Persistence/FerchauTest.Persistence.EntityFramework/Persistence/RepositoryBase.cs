using FerchauTest.Persistence.EntityFramework.Persistence.Extensions;
using FerchauTest.Shared.SeedWork;
using FerchauTest.Shared.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FerchauTest.Persistence.EntityFramework.Persistence
{
	public class RepositoryBase<TEntity, Tkey> : IRepository<TEntity, Tkey> where TEntity : Entity<Tkey>, IAggregateRoot
	{
		protected readonly FerchauDbContext DbContext;

		protected virtual IQueryable<TEntity> ConfigureInclude(IQueryable<TEntity> query)
		{
			return query;
		}

		public RepositoryBase(FerchauDbContext dbContext)
		{
			DbContext = dbContext;
		}

		public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
		{
			await DbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
		}

		public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
		{
			DbContext.Set<TEntity>().Update(entity);

			return Task.CompletedTask;
		}

		public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
		{
			EntityEntry<TEntity> entry = DbContext.Attach(entity);

			entry.CurrentValues["IsDeleted"] = true;
			entry.CurrentValues["DeletedAt"] = DateTimeOffset.Now;

			DbContext.Update(entity);

			return Task.CompletedTask;
		}

		public Task<TEntity> GetAsync(Tkey id, CancellationToken cancellationToken)
		{
			return DbContext.Set<TEntity>()
				.Apply(ConfigureInclude)
				.SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
		}
	}

	public class RepositoryBase<TEntity> : RepositoryBase<TEntity, Guid> where TEntity : Entity<Guid>, IAggregateRoot
	{
		public RepositoryBase(FerchauDbContext dbContext) : base(dbContext)
		{
		}
	}
}
