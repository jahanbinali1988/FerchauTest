using FerchauTest.Application.Contract.Cars.Commands;
using FerchauTest.Domain.Cars;
using FerchauTest.Shared.Application;
using FerchauTest.Shared.SeedWork;

namespace FerchauTest.Application.Cars.CommandHandlers
{
	public class UpdateCarCommandHandler : ICommandHandler<UpdateCarCommand, long>
	{
		private readonly ICarRepository _carRepository;
		private readonly IUnitOfWork _unitOfWork;
		public UpdateCarCommandHandler(ICarRepository carRepository,
			IUnitOfWork unitOfWork)
		{
			_carRepository = carRepository;
			_unitOfWork = unitOfWork;
		}
		public async Task<long> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
		{
			var car = await _carRepository.GetAsync(request.Id, cancellationToken);

			car.Update(request.Brand, request.Model);

			await _carRepository.UpdateAsync(car, cancellationToken);
			await _unitOfWork.CommitAsync(cancellationToken);

			return car.Id;
		}
	}
}
