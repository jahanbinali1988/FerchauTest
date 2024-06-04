using FerchauTest.Domain.Cars;
using FerchauTest.Domain.Customers;
using FerchauTest.Persistence.EntityFramework.Persistence;

namespace FerchauTest.Persistence.EntityFramework.Domain.Cars
{
	public class CarRepository : RepositoryBase<Customer, long>, ICarRepository
	{
		public CarRepository(FerchauDbContext dbContext) : base(dbContext)
		{
		}
	}
}
