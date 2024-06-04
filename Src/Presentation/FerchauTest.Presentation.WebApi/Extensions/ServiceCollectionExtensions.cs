using MediatR;
using FerchauTest.Persistence.EntityFramework.Extensions;
using FerchauTest.Application;

namespace FerchauTest.Presentation.WebApi.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
		{
			services.AddMediatR(typeof(Startup).Assembly, typeof(AssembelyRecognizer).Assembly);

			services.AddConnection(configuration);
			return services;
		}
	}
}
