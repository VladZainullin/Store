using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infrastructure.Persistence.Configurations;

internal sealed class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder
            .Property(p => p.Id)
            .HasConversion(e => e.Value, v => v);

        builder
            .Property(p => p.Name)
            .HasConversion(e => e.Value, v => v);
    }
}