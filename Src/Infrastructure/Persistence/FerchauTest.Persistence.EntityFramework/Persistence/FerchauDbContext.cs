using FerchauTest.Domain.Cars;
using FerchauTest.Domain.Cars.Entities;
using FerchauTest.Domain.Customers;
using FerchauTest.Persistence.EntityFramework.Domain.Cars.EntityTypeConfigurations;
using FerchauTest.Persistence.EntityFramework.Domain.Customers.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FerchauTest.Persistence.EntityFramework.Persistence
{
	public class FerchauDbContext : DbContext
	{
		public FerchauDbContext(DbContextOptions options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
			builder.ApplyConfiguration(new CarEntityTypeConfiguration());
			builder.ApplyConfiguration(new ContractEntityTypeConfiguration());

			base.OnModelCreating(builder);
			builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

		}

		public DbSet<Customer> Customers { get; set; }
		public DbSet<Car> Cars { get; set; }
		public DbSet<Contract> Contracts { get; set; }
	}
}
