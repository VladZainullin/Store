using Domain.Entities.Addresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal sealed class AddressConfiguration : 
    IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.Property(static p => p.Id).HasField("_id");
        
        builder.Property(static c => c.Title).HasField("_title");
        
        builder.Property(static c => c.Street).HasField("_street");
        builder.Property(static c => c.House).HasField("_house");
        builder.Property(static c => c.Root).HasField("_root");
        builder.Property(static c => c.Number).HasField("_number");
        
        builder.Property(static c => c.Comment).HasField("_comment");
        
        builder.Property(static c => c.CreatedAt).HasField("_createdAt");
        builder.Property(static c => c.UpdatedAt).HasField("_updatedAt");
        builder.Property(static c => c.RemovedAt).HasField("_removedAt");
        
        builder.ToTable("addresses");
    }
}