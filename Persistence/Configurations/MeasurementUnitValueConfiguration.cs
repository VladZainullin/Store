using Domain.Entities.MeasurementUnitValues;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal sealed class MeasurementUnitValueConfiguration : IEntityTypeConfiguration<MeasurementUnitValue>
{
    public void Configure(EntityTypeBuilder<MeasurementUnitValue> builder)
    {
        builder.Property(static mu => mu.Id).HasField("_id");
        builder.Property(static mu => mu.Value).HasField("_value");
        builder.Property(static mu => mu.CreatedAt).HasField("_createdAt");
        builder.Property(static mu => mu.UpdatedAt).HasField("_updatedAt");
        builder.Property(static mu => mu.RemovedAt).HasField("_removedAt");

        builder.HasOne(static mu => mu.MeasurementUnit).WithMany();
        
        builder.ToTable("measurement_units");
    }
}