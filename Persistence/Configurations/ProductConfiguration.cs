using Domain.Entities;
using Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(static m => m.Id).HasField("_id").ValueGeneratedNever();
        builder.Property(static m => m.Title).HasField("_title");
        builder.Property(static m => m.Description).HasField("_description");

        builder.HasIndex(static m => m.Title).IsUnique();
    }
}