using Domain.Entities.ProductPositions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal sealed class ProductPositionConfiguration : IEntityTypeConfiguration<ProductPosition>
{
    public void Configure(EntityTypeBuilder<ProductPosition> builder)
    {
        builder.Property(static m => m.Id).HasField("_id").ValueGeneratedNever();
        builder.Property(static m => m.MeasurementUnitPositionId).HasField("_measurementUnitPositionId");
        builder.Property(static m => m.UpdatedAt).HasField("_updatedAt");
        builder.Property(static m => m.CreatedAt).HasField("_createdAt");

        builder
            .HasIndex(static m => new
            {
                m.ProductId,
                m.MeasurementUnitPositionId
            })
            .IsUnique();

        builder.HasOne(static vp => vp.Product).WithMany(static v => v.Positions);
    }
}