using FerchauTest.Domain.Cars.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FerchauTest.Persistence.EntityFramework.Domain.Cars.EntityTypeConfigurations
{
	public class ContractEntityTypeConfiguration : IEntityTypeConfiguration<Contract>
	{
		public void Configure(EntityTypeBuilder<Contract> builder)
		{
			builder.HasIndex(x => x.Id)
				.IsUnique();
			builder.Property(current => current.Id).ValueGeneratedNever();

			builder.Property(p => p.StartDate).IsRequired(true);

			builder.Property(p => p.EndDate).IsRequired(true);

			builder.Property(p => p.IsFinished).IsRequired(true);

			builder.Property(p => p.UsedKilometers).IsRequired(true);

			builder.OwnsOne(p => p.CustomerId, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(Contract.CustomerId))
					.IsRequired(true);
			});

			builder.OwnsOne(p => p.CarId, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(Contract.CarId))
					.IsRequired(true);
			});

			builder.HasOne(c => c.Customer);
			
			builder.Property(x => x.CreatedAt)
				.HasDefaultValueSql("SYSDATETIMEOFFSET()");

			builder.Property<bool>("IsDeleted")
				.HasDefaultValue(false);

			builder.Property<DateTimeOffset?>("DeletedAt")
				.IsRequired(false);

			builder.Ignore(x => x.DomainEvents);
			builder.Ignore(x => x.Version);

			builder.HasQueryFilter(p => EF.Property<bool>(p, "IsDeleted") == false);

			builder.ToTable(nameof(Contract));
		}
	}
}
