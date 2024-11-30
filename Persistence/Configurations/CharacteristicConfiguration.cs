using Domain.Entities.Characteristics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal sealed class CharacteristicConfiguration : IEntityTypeConfiguration<Characteristic>
{
    public void Configure(EntityTypeBuilder<Characteristic> builder)
    {
        builder.Property(static fp => fp.Id).ValueGeneratedNever();
        
        builder.Property(static fp => fp.Title).HasField("_title");
        
        builder.Property(static fp => fp.CreatedAt).HasField("_createdAt");
        builder.Property(static fp => fp.UpdatedAt).HasField("_updatedAt");
        builder.Property(static fp => fp.RemovedAt).HasField("_removedAt");
        
        builder.ToTable("characteristics");
    }
}