using Domain.Entities.Carts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal sealed class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.Property(static c => c.Id).HasField("_id").ValueGeneratedNever();
        builder.Property(static c => c.ClientId).HasField("_clientId");
        builder.Property(static c => c.UpdatedAt).HasField("_updatedAt");
        builder.Property(static c => c.CreatedAt).HasField("_createdAt");

        builder.HasMany(static c => c.Products).WithOne();
    }
}