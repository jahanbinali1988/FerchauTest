using FerchauTest.Application.Contract.Cars.Commands;
using FerchauTest.Application.Contract.Cars.Dtos;
using FerchauTest.Application.Contract.Cars.Queries;
using FerchauTest.Presentation.WebApi.Controllers.Cars.Models;
using FerchauTest.Shared.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FerchauTest.Presentation.WebApi.Controllers.Cars
{
	[ApiController]
	[Route("cars")]
	public class CarController : ControllerBase
	{
		private readonly ILogger<CarController> _logger;
		private readonly IMediator _mediator;
		public CarController(ILogger<CarController> logger, IMediator mediator)
		{
			_logger = logger;
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<long> CreateAsync([FromBody] CreateOrUpdateCarModel model, CancellationToken cancellationToken)
		{
			var query = new CreateCarCommand(model.Brand, model.Model);

			var id = await _mediator.Send(query, cancellationToken);

			return id;
		}

		[HttpPut("{carId}")]
		public async Task<long> UpdateAsync([FromRoute] long carId, [FromBody] CreateOrUpdateCarModel model, CancellationToken cancellationToken)
		{
			var query = new UpdateCarCommand(carId, model.Brand, model.Model);

			var id = await _mediator.Send(query, cancellationToken);

			return id;
		}

		[HttpDelete("{carId}")]
		public async Task UpdateAsync([FromRoute] long carId, CancellationToken cancellationToken)
		{
			var query = new DeleteCarCommand(carId);

			await _mediator.Send(query, cancellationToken);
		}

		[HttpGet("list")]
		public async Task<Pagination<CarDto>> GetListAsync([FromQuery] GetAllCarModel getAllCarModel, CancellationToken cancellationToken)
		{
			var query = new GetCarsQuery(getAllCarModel.PageSize, getAllCarModel.PageCount);

			var cars = await _mediator.Send(query, cancellationToken);

			return cars;
		}

		[HttpGet("{carId}")]
		public async Task<CarDto?> GetAsync([FromRoute] long carId, CancellationToken cancellationToken)
		{
			var query = new GetCarByIdQuery(carId);

			var cas = await _mediator.Send(query, cancellationToken);

			return cas;
		}
	}
}
