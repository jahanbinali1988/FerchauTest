using FerchauTest.Application.Contract.Customers.Commands;
using FerchauTest.Application.Contract.Customers.Dtos;
using FerchauTest.Application.Contract.Customers.Queries;
using FerchauTest.Presentation.WebApi.Controllers.Customers.Models;
using FerchauTest.Shared.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FerchauTest.Presentation.WebApi.Controllers.Customers
{
	[ApiController]
	[Route("customers")]
	public class CustomerController : ControllerBase
	{
		private readonly ILogger<CustomerController> _logger;
		private readonly IMediator _mediator;
		public CustomerController(ILogger<CustomerController> logger, IMediator mediator)
		{
			_logger = logger;
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<long> CreateAsync([FromBody] CreateOrUpdateCustomerModel model, CancellationToken cancellationToken)
		{
			var query = new CreateCustomerCommand(model.FirstName, model.LastName, model.PhoneNumber);

			var id = await _mediator.Send(query, cancellationToken);

			return id;
		}

		[HttpPut("{customerId}")]
		public async Task<long> UpdateAsync([FromRoute] long customerId, [FromBody] CreateOrUpdateCustomerModel model, CancellationToken cancellationToken)
		{
			var query = new UpdateCustomerCommand(customerId, model.FirstName, model.LastName, model.PhoneNumber);

			var id = await _mediator.Send(query, cancellationToken);

			return id;
		}

		[HttpDelete("{customerId}")]
		public async Task UpdateAsync([FromRoute] long customerId, CancellationToken cancellationToken)
		{
			var query = new DeleteCustomerCommand(customerId);

			await _mediator.Send(query, cancellationToken);
		}

		[HttpGet("list")]
		public async Task<Pagination<CustomerDto>> GetListAsync([FromQuery] GetAllCustomerModel getAllCustomerModel, CancellationToken cancellationToken)
		{
			var query = new GetCustomersQuery(getAllCustomerModel.PageSize, getAllCustomerModel.PageCount);

			var customers = await _mediator.Send(query, cancellationToken);

			return customers;
		}

		[HttpGet("{customerId}")]
		public async Task<CustomerDto?> GetAsync([FromRoute] long customerId, CancellationToken cancellationToken)
		{
			var query = new GetCustomerByIdQuery(customerId);

			var customers = await _mediator.Send(query, cancellationToken);

			return customers;
		}
	}
}