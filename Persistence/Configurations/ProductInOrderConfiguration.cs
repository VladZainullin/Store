using Domain.Entities.ProductInOrders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal sealed class ProductInOrderConfiguration : IEntityTypeConfiguration<ProductInOrder>
{
    public void Configure(EntityTypeBuilder<ProductInOrder> builder)
    {
        builder.Property(static pio => pio.Id).HasField("_id");
        builder.Property(static pio => pio.CreatedAt).HasField("_createdAt");
        builder.Property(static pio => pio.UpdatedAt).HasField("_updatedAt");
        builder.Property(static pio => pio.Quantity).HasField("_quantity");
        builder.Property(static pio => pio.Cost).HasField("_cost");

        builder.HasOne(static pio => pio.Product).WithMany();
        builder.HasOne(static pio => pio.Order).WithMany();
    }
}