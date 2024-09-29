using Domain.Entities.VodkaPositions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal sealed class VodkaPositionConfiguration : IEntityTypeConfiguration<VodkaPosition>
{
    public void Configure(EntityTypeBuilder<VodkaPosition> builder)
    {
        builder.Property(static m => m.Id).HasField("_id").ValueGeneratedNever();
        builder.Property(static m => m.VolumeId).HasField("_volumeId");

        builder
            .HasIndex(static m => new
            {
                m.VodkaId, MeasurementUnitPositionId = m.VolumeId
            })
            .IsUnique();

        builder.HasOne(static vp => vp.Vodka).WithMany(static v => v.Positions);
    }
}