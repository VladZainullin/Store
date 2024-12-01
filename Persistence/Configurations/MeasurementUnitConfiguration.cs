using Domain.Entities.MeasurementUnits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal sealed class MeasurementUnitConfiguration : IEntityTypeConfiguration<MeasurementUnit>
{
    public void Configure(EntityTypeBuilder<MeasurementUnit> builder)
    {
        builder.Property(static mu => mu.Id).HasField("_id").ValueGeneratedNever();
        builder.Property(static mu => mu.ShortTitle).HasField("_shortTitle");
        builder.Property(static mu => mu.FullTitle).HasField("_fullTitle");
        builder.Property(static mu => mu.CreatedAt).HasField("_createdAt");
        builder.Property(static mu => mu.UpdatedAt).HasField("_updatedAt");
        builder.Property(static mu => mu.RemovedAt).HasField("_removedAt");
        
        builder.ToTable("measurement_units");
    }
}