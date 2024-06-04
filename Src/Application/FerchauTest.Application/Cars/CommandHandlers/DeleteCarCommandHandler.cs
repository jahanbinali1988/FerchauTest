using FerchauTest.Application.Contract.Cars.Commands;
using FerchauTest.Application.Contract.Customers.Exceptions;
using FerchauTest.Domain.Cars;
using FerchauTest.Shared.Application;
using FerchauTest.Shared.Exceptions;
using FerchauTest.Shared.SeedWork;
using MediatR;

namespace FerchauTest.Application.Cars.CommandHandlers
{
	public class DeleteCarCommandHandler : ICommandHandler<DeleteCarCommand>
	{
		private readonly ICarRepository _carRepository;
		private readonly IUnitOfWork _unitOfWork;
		public DeleteCarCommandHandler(ICarRepository carRepository, IUnitOfWork unitOfWork)
		{
			_carRepository = carRepository;
			_unitOfWork = unitOfWork;
		}
		public async Task<Unit> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
		{
			var customer = await _carRepository.GetAsync(request.CarId, cancellationToken);
			if (customer == null)
				throw new UnableToFindCustomerException(ExceptionsEnum.UnableToFindCustomerException, request.CarId.ToString());

			customer.Delete();
			await _unitOfWork.CommitAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
