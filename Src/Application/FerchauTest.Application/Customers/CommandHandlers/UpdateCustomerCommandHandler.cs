using FerchauTest.Application.Contract.Customers.Commands;
using FerchauTest.Application.Contract.Customers.Exceptions;
using FerchauTest.Domain.Customers;
using FerchauTest.Shared.Application;
using FerchauTest.Shared.Exceptions;
using FerchauTest.Shared.SeedWork;

namespace FerchauTest.Application.Customers.CommandHandlers
{
	public class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommand, long>
	{
		private readonly ICustomerRepository _customerRepository;
		private readonly IUnitOfWork _unitOfWork;
		public UpdateCustomerCommandHandler(ICustomerRepository customerRepository,
			IUnitOfWork unitOfWork)
		{
			_customerRepository = customerRepository;
			_unitOfWork = unitOfWork;
		}
		public async Task<long> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
		{
			var customer = await _customerRepository.GetAsync(request.Id, cancellationToken);
			if (customer == null)
				throw new UnableToFindCustomerException(ExceptionsEnum.UnableToFindCustomerException, request.Id.ToString());

			customer.Update(request.FirstName, request.LastName, request.PhoneNumber);

			await _customerRepository.UpdateAsync(customer, cancellationToken);
			await _unitOfWork.CommitAsync(cancellationToken);

			return customer.Id;
		}
	}
}
