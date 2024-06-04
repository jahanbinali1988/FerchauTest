using FerchauTest.Persistence.EntityFramework.EventProcessing;
using FerchauTest.Persistence.EntityFramework.Persistence;
using FerchauTest.Shared.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FerchauTest.Shared.SeedWork;
using FerchauTest.Shared.EventProcessing.DomainEvent;
using FerchauTest.Domain.Customers;
using FerchauTest.Persistence.EntityFramework.Domain.Customers;
using FerchauTest.Domain.Cars;
using FerchauTest.Persistence.EntityFramework.Domain.Cars;
using FerchauTest.Domain.Customers.DomainServices;

namespace FerchauTest.Persistence.EntityFramework.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
		{
			var mssqlConnection = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
			services.AddDbContext<FerchauDbContext>(options => options.
			   UseSqlServer(mssqlConnection));

			services.AddTransient<ICustomerRepository, CustomerRepository>();
			services.AddTransient<ICustomerExistenceService, CustomerExistenceService>();

			services.AddTransient<ICarRepository, CarRepository>();

			services.AddTransient<IUnitOfWork, UnitOfWork>();
			services.AddTransient<IDomainEventsDispatcher, DomainEventsDispatcher>();

			services.AddTransient<IIdGenerator, SnowflakeIdGenerator>();

			return services;
		}

		public static IServiceCollection AddConnection(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddRepository(configuration);

			return services;
		}
	}
}
