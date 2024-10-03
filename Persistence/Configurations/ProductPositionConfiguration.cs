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

        builder
            .HasIndex(static m => new
            {
                VodkaId = m.ProductId,
                m.MeasurementUnitPositionId
            })
            .IsUnique();

        builder.HasOne(static vp => vp.Product).WithMany(static v => v.Positions);
    }
}