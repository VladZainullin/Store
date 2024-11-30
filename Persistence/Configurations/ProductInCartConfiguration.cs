using Domain.Entities.ProductInCarts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal sealed class ProductInCartConfiguration : IEntityTypeConfiguration<ProductInCart>
{
    public void Configure(EntityTypeBuilder<ProductInCart> builder)
    {
        builder.Property(static pic => pic.Id).HasField("_id").ValueGeneratedNever();
        builder.Property(static pic => pic.CreatedAt).HasField("_createdAt");
        builder.Property(static pic => pic.UpdatedAt).HasField("_updatedAt");
        builder.Property(static pic => pic.Quantity).HasField("_quantity");
        
        builder.HasOne(static pic => pic.Cart).WithMany(static c => c.Products);
        builder.HasOne(static pic => pic.Product).WithMany();
        
        builder.ToTable("product_in_carts");
    }
}