using FerchauTest.Domain.Cars;
using FerchauTest.Persistence.EntityFramework.Persistence;
using FerchauTest.Shared.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace FerchauTest.Persistence.EntityFramework.Domain.Cars
{
	public class CarRepository : RepositoryBase<Car, long>, ICarRepository
	{
		public CarRepository(FerchauDbContext dbContext) : base(dbContext)
		{
		}

		protected override IQueryable<Car> ConfigureInclude(IQueryable<Car> query)
		{
			return query.Include(i=> i.Contracts);
		}
	}
}
