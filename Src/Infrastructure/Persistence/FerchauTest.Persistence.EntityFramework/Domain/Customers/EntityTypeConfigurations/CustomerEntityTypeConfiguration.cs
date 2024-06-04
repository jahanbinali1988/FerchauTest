using FerchauTest.Domain.Customers;
using FerchauTest.Domain.Customers.Constants;
using FerchauTest.Domain.Customers.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FerchauTest.Persistence.EntityFramework.Domain.Customers.EntityTypeConfigurations
{
	public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
	{
		public void Configure(EntityTypeBuilder<Customer> builder)
		{
			builder.HasIndex(x => x.Id)
				.IsUnique();
			builder.Property(current => current.Id).ValueGeneratedNever();

			builder.OwnsOne(p => p.Firstname, pp =>
			{
				pp.Property(current => current.Value)
					.HasColumnName(nameof(FirstName))
					.HasMaxLength(ConstantValues.MaximumFirstnameLength);
			});

			builder.OwnsOne(p => p.Lastname, pp =>
			{
				pp.Property(current => current.Value)
					.HasColumnName(nameof(LastName))
					.HasMaxLength(ConstantValues.MaximumLastnameLength);
			});

			builder.OwnsOne(p => p.PhoneNumber, pp =>
			{
				pp.Property(current => current.Value)
					.HasColumnName(nameof(PhoneNumber))
					.HasMaxLength(ConstantValues.MaximumPhoneNumberLength);
			});

			builder.Property(x => x.CreatedAt)
				.HasDefaultValueSql("SYSDATETIMEOFFSET()");

			builder.Property<bool>("IsDeleted")
				.HasDefaultValue(false);

			builder.Property<DateTimeOffset?>("DeletedAt")
				.IsRequired(false);

			builder.Ignore(x => x.DomainEvents);
			builder.Ignore(x => x.Version);

			builder.HasQueryFilter(p => EF.Property<bool>(p, "IsDeleted") == false);

			builder.ToTable(nameof(Customer));
		}
	}
}
