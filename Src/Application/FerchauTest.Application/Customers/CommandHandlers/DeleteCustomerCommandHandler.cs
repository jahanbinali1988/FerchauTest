using FerchauTest.Application.Contract.Customers.Commands;
using FerchauTest.Application.Contract.Customers.Exceptions;
using FerchauTest.Domain.Customers;
using FerchauTest.Shared.Application;
using FerchauTest.Shared.Exceptions;
using FerchauTest.Shared.SeedWork;
using MediatR;

namespace FerchauTest.Application.Customers.CommandHandlers
{
	public class DeleteCustomerCommandHandler : ICommandHandler<DeleteCustomerCommand>
	{
		private readonly ICustomerRepository _customerRepository;
		private readonly IUnitOfWork _unitOfWork;
		public DeleteCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
		{
			_customerRepository = customerRepository;
			_unitOfWork = unitOfWork;
		}
		public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
		{
			var customer = await _customerRepository.GetAsync(request.CustomerId, cancellationToken);
			if (customer == null)
				throw new UnableToFindCustomerException(request.CustomerId.ToString());

			customer.Delete();
			await _unitOfWork.CommitAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
