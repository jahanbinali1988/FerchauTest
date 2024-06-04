namespace FerchauTest.Domain.Customers.DomainServices
{
	public class CustomerExistenceService : ICustomerExistenceService
	{
		private readonly ICustomerRepository _repository;
		public CustomerExistenceService(ICustomerRepository repository)
		{
			_repository = repository;
		}

		public Task<bool> IsExistedAsync(long id)
		{
			return _repository.AnyAsync(id);
		}
	}
	public interface ICustomerExistenceService
	{
		Task<bool> IsExistedAsync(long id);
	}
}
