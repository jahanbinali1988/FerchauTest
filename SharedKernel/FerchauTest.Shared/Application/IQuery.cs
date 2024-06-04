using MediatR;

namespace FerchauTest.Shared.Application
{
	public interface IQuery<out TResult> : IRequest<TResult>
	{

	}
}
