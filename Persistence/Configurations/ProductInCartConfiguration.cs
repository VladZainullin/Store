using Domain.Entities.ProductInCarts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal sealed class ProductInCartConfiguration : IEntityTypeConfiguration<ProductInCart>
{
    public void Configure(EntityTypeBuilder<ProductInCart> builder)
    {
        builder.Property(static c => c.Id).HasField("_id").ValueGeneratedNever();
        builder.Property(static c => c.ProductId).HasField("_productId");
        builder.Property(static c => c.BucketId).HasField("_bucketId");
        builder.Property(static c => c.CreatedAt).HasField("_createdAt");
        builder.Property(static c => c.UpdatedAt).HasField("_updatedAt");
        builder.Property(static c => c.Quantity).HasField("_quantity");
    }
}