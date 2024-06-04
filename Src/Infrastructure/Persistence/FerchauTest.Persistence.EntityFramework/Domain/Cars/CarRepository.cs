using FerchauTest.Domain.Cars;
using FerchauTest.Persistence.EntityFramework.Persistence;

namespace FerchauTest.Persistence.EntityFramework.Domain.Cars
{
	public class CarRepository : RepositoryBase<Car, long>, ICarRepository
	{
		public CarRepository(FerchauDbContext dbContext) : base(dbContext)
		{
		}
	}
}
