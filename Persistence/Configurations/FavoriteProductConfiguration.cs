using Domain.Entities.FavoriteProducts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal sealed class FavoriteProductConfiguration : 
    IEntityTypeConfiguration<FavoriteProduct>
{
    public void Configure(EntityTypeBuilder<FavoriteProduct> builder)
    {
        builder.Property(static fp => fp.Id).ValueGeneratedNever();
        
        builder.Property(static fp => fp.ClientId).HasField("_clientId");
        
        builder.Property(static fp => fp.CreatedAt).HasField("_createdAt");
        builder.Property(static fp => fp.UpdatedAt).HasField("_updatedAt");
        builder.Property(static fp => fp.RemovedAt).HasField("_removedAt");

        builder
            .HasOne(static fp => fp.Product)
            .WithMany(static p => p.Favorites);
        
        builder.ToTable("favorite_products");
    }
}