using FerchauTest.Application.Contract.Customers.Commands;
using FerchauTest.Domain.Customers;
using FerchauTest.Shared.Application;
using FerchauTest.Shared.SeedWork;
using FerchauTest.Shared.Shared;

namespace FerchauTest.Application.Customers.CommandHandlers
{
	public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand, long>
	{
		private readonly ICustomerRepository _customerRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IIdGenerator _idGenerator;
		public CreateCustomerCommandHandler(ICustomerRepository customerRepository,
			IUnitOfWork unitOfWork,
			IIdGenerator idGenerator)
		{
			_customerRepository = customerRepository;
			_unitOfWork = unitOfWork;
			_idGenerator = idGenerator;
		}

		public async Task<long> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
		{
			var customer = Customer.Create(request.FirstName, request.LastName, request.PhoneNumber, _idGenerator);

			await _customerRepository.AddAsync(customer, cancellationToken);

			await _unitOfWork.CommitAsync(cancellationToken);

			return customer.Id;
		}
	}
}
