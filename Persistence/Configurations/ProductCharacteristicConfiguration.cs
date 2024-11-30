using Domain.Entities.ProductCharacteristics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal sealed class ProductCharacteristicConfiguration : 
    IEntityTypeConfiguration<ProductCharacteristic>
{
    public void Configure(EntityTypeBuilder<ProductCharacteristic> builder)
    {
        builder.Property(static pc => pc.Id).HasField("_id");
        builder.Property(static pc => pc.Value).HasField("_value");
        builder.Property(static pc => pc.CreatedAt).HasField("_createdAt");
        builder.Property(static pc => pc.UpdatedAt).HasField("_updatedAt");
        builder.Property(static pc => pc.RemovedAt).HasField("_removedAt");

        builder.HasOne(static pc => pc.Product).WithMany();
        builder.HasOne(static pc => pc.Characteristic).WithMany();
        
        builder.ToTable("product_characteristics");
    }
}