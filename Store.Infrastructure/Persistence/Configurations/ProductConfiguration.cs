using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infrastructure.Persistence.Configurations;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .Property(p => p.Title)
            .HasConversion(e => e.Value, v => v);

        builder
            .Property(p => p.Description)
            .HasConversion(e => e.Value, v => v);

        builder
            .Property(p => p.Cost)
            .HasConversion(e => e.Value, v => v);

        builder
            .Property(p => p.Id)
            .HasConversion(e => e.Value, v => v);
    }
}