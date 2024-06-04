using System.Threading;
using System.Threading.Tasks;

namespace FerchauTest.Shared.SeedWork
{
	public interface IUnitOfWork
	{
		Task<int> CommitAsync(CancellationToken cancellationToken = default);
	}
}
