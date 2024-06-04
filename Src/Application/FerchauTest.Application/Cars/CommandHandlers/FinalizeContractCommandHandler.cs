using FerchauTest.Application.Contract.Cars.Commands;
using FerchauTest.Application.Contract.Cars.Exceptions;
using FerchauTest.Domain.Cars;
using FerchauTest.Shared.Application;
using FerchauTest.Shared.SeedWork;
using MediatR;

namespace FerchauTest.Application.Cars.CommandHandlers
{
	internal class FinalizeContractCommandHandler : ICommandHandler<FinalizeContractCommand>
	{
		private readonly ICarRepository _carRepository;
		private readonly IUnitOfWork _unitOfWork;
		public FinalizeContractCommandHandler(ICarRepository carRepository, IUnitOfWork unitOfWork)
		{
			_carRepository = carRepository;
			_unitOfWork = unitOfWork;
		}

		public async Task<Unit> Handle(FinalizeContractCommand request, CancellationToken cancellationToken)
		{
			var car = await _carRepository.GetAsync(request.CarId, cancellationToken);
			if (car == null)
				throw new UnableToFindCarException(request.CarId.ToString());

			car.FinishContract(request.ContractId, request.UsedKilometers);

			await _unitOfWork.CommitAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
