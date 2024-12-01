using Domain.Entities.ProductInOrders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal sealed class ProductInOrderConfiguration : IEntityTypeConfiguration<ProductInOrder>
{
    public void Configure(EntityTypeBuilder<ProductInOrder> builder)
    {
        builder.Property(static pio => pio.Id).HasField("_id").ValueGeneratedNever();
        builder.Property(static pio => pio.CreatedAt).HasField("_createdAt");
        builder.Property(static pio => pio.UpdatedAt).HasField("_updatedAt");
        builder.Property(static pio => pio.RemovedAt).HasField("_removedAt");
        builder.Property(static pio => pio.Quantity).HasField("_quantity");
        builder.Property(static pio => pio.Cost).HasField("_cost");

        builder.HasOne(static pio => pio.Product).WithMany(static p => p.ProductInOrders);
        builder.HasOne(static pio => pio.Order).WithMany(static o => o.Products);
        
        builder.ToTable("product_in_orders");
    }
}