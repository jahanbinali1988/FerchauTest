using FerchauTest.Domain.Cars;
using FerchauTest.Domain.Cars.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FerchauTest.Persistence.EntityFramework.Domain.Cars.EntityTypeConfigurations
{
	public class CarEntityTypeConfiguration : IEntityTypeConfiguration<Car>
	{
		public void Configure(EntityTypeBuilder<Car> builder)
		{
			builder.HasIndex(x => x.Id)
				.IsUnique();
			builder.Property(current => current.Id).ValueGeneratedNever();

			builder.Property(p => p.TotalKilometres).HasDefaultValue(0).IsRequired(true);

			builder.OwnsOne(p => p.Brand, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(Car.Brand))
					.HasMaxLength(ConstantValues.MaximumBrandLength)
					.IsRequired(true);
			});

			builder.OwnsOne(p => p.Model, m =>
			{
				m.Property(x => x.Value)
					.HasColumnName(nameof(Car.Model))
					.HasMaxLength(ConstantValues.MaximumModelLength)
					.IsRequired(true);
			});

			builder.HasMany(c => c.Contracts).WithOne(x => x.Car);

			builder.Property(x => x.CreatedAt)
				.HasDefaultValueSql("SYSDATETIMEOFFSET()");

			builder.Property<bool>("IsDeleted")
				.HasDefaultValue(false);

			builder.Property<DateTimeOffset?>("DeletedAt")
				.IsRequired(false);

			builder.Ignore(x => x.DomainEvents);
			builder.Ignore(x => x.Version);

			builder.HasQueryFilter(p => EF.Property<bool>(p, "IsDeleted") == false);

			builder.ToTable(nameof(Car));
		}
	}
}
