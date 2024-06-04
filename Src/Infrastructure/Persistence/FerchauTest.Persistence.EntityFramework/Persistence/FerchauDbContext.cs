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
			base.OnModelCreating(builder);
			builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

		}
	}
}
