using System;
using MediatR;

namespace FerchauTest.Shared.Application
{
	public interface ICommand : IRequest
	{
		Guid CommandId { get; }
	}

	public interface ICommand<out TResult> : IRequest<TResult>
	{
		Guid CommandId { get; }
	}
}
