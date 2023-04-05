using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infrastructure.Persistence.Configurations;

internal sealed class StreetConfiguration : IEntityTypeConfiguration<Street>
{
    public void Configure(EntityTypeBuilder<Street> builder)
    {
        builder
            .Property(p => p.Id)
            .HasConversion(e => e.Value, v => v);

        builder
            .Property(p => p.Name)
            .HasConversion(e => e.Value, v => v);
    }
}