using FerchauTest.Application.Contract.Cars.Commands;
using FerchauTest.Application.Contract.Cars.Exceptions;
using FerchauTest.Application.Contract.Customers.Exceptions;
using FerchauTest.Domain.Cars;
using FerchauTest.Domain.Customers;
using FerchauTest.Domain.Customers.DomainServices;
using FerchauTest.Shared.Application;
using FerchauTest.Shared.Exceptions;
using FerchauTest.Shared.SeedWork;
using FerchauTest.Shared.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FerchauTest.Application.Cars.CommandHandlers
{
	public class CreateContractCommandHandler : ICommandHandler<CreateContractCommand>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ICustomerRepository _customerRepository;
		private readonly ICarRepository _carRepository;
		private readonly IIdGenerator _idGenerator; 
		private readonly ICustomerExistenceService _customerExistenceService;
		public CreateContractCommandHandler(ICarRepository carRepository, ICustomerRepository customerRepository, IIdGenerator idGenerator, ICustomerExistenceService customerExistenceService, IUnitOfWork unitOfWork)
		{
			_carRepository = carRepository;
			_customerRepository = customerRepository;
			_idGenerator = idGenerator;
			_customerExistenceService = customerExistenceService;
			_unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(CreateContractCommand request, CancellationToken cancellationToken)
		{
			var car = await _carRepository.GetAsync(request.CarId, cancellationToken);
			if (car == null)
				throw new UnableToFindCarException(request.CarId.ToString());

			var customer = await _customerRepository.GetAsync(request.CustomerId, cancellationToken);
			if (customer == null)
				throw new UnableToFindCustomerException(request.CustomerId.ToString());

			await car.AssignContractAsync(request.CustomerId, request.CarId, request.StartDate, request.EndDate, _idGenerator, _customerExistenceService);
			await _unitOfWork.CommitAsync(cancellationToken);
			
			return Unit.Value;
		}
	}
}
