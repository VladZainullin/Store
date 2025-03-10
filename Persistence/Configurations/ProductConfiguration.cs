using Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(static m => m.Id).HasField("_id").ValueGeneratedNever();
        builder.Property(static m => m.Title).HasField("_title").HasMaxLength(200);
        builder.Property(static p => p.Cost).HasField("_cost");
        builder.Property(static p => p.Quantity).HasField("_quantity");
        builder.Property(static m => m.Description).HasField("_description").HasMaxLength(6000);
        builder.Property(static m => m.UpdatedAt).HasField("_updatedAt");
        builder.Property(static m => m.CreatedAt).HasField("_createdAt");
        builder.Property(static m => m.RemovedAt).HasField("_removedAt");

        builder.HasIndex(static m => m.Title).IsUnique();
        
        builder.ToTable("products");
    }
}