using FerchauTest.Application.Contract.Cars.Commands;
using FerchauTest.Domain.Cars;
using FerchauTest.Shared.Application;
using FerchauTest.Shared.SeedWork;
using FerchauTest.Shared.Shared;

namespace FerchauTest.Application.Cars.CommandHandlers
{
	public class CreateCarCommandHandler : ICommandHandler<CreateCarCommand, long>
	{
		private readonly ICarRepository _carRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IIdGenerator _idGenerator;
		public CreateCarCommandHandler(ICarRepository carRepository,
			IUnitOfWork unitOfWork,
			IIdGenerator idGenerator)
		{
			_carRepository = carRepository;
			_unitOfWork = unitOfWork;
			_idGenerator = idGenerator;
		}

		public async Task<long> Handle(CreateCarCommand request, CancellationToken cancellationToken)
		{
			var car = Car.Create(request.Brand, request.Model, _idGenerator);

			await _carRepository.AddAsync(car, cancellationToken);

			await _unitOfWork.CommitAsync(cancellationToken);

			return car.Id;
		}
	}
}
