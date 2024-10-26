using Domain.Buckets.Entities.Buckets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal sealed class BucketConfiguration : IEntityTypeConfiguration<Bucket>
{
    public void Configure(EntityTypeBuilder<Bucket> builder)
    {
        builder.Property(static c => c.Id).HasField("_id").ValueGeneratedNever();
        builder.Property(static c => c.ClientId).HasField("_clientId");
        builder.Property(static c => c.UpdatedAt).HasField("_updatedAt");
        builder.Property(static c => c.CreatedAt).HasField("_createdAt");

        builder.HasMany(static c => c.Products).WithOne();
    }
}