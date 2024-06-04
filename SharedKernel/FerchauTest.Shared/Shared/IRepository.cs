using FerchauTest.Shared.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerchauTest.Shared.Shared
{
	public interface IRepository<TEntity, Tkey> where TEntity : Entity<Tkey>, IAggregateRoot
	{
		Task AddAsync(TEntity entity, CancellationToken cancellationToken);

		Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);

		Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);

		Task<TEntity> GetAsync(Tkey id, CancellationToken cancellationToken);
	}

	public interface IRepository<TEntity> : IRepository<TEntity, long> where TEntity : Entity<long>, IAggregateRoot
	{

	}
}
