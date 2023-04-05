using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infrastructure.Persistence.Configurations;

internal sealed class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder
            .Property(p => p.Id)
            .HasConversion(e => e.Value, v => v);

        builder
            .Property(p => p.ApartmentNumber)
            .HasConversion(e => e.Value, v => v);

        builder
            .Property(p => p.HouseNumber)
            .HasConversion(e => e.Value, v => v);
    }
}