using Domain.Entities.ProductInCategories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal sealed class ProductInCategoryConfiguration : 
    IEntityTypeConfiguration<ProductInCategory>
{
    public void Configure(EntityTypeBuilder<ProductInCategory> builder)
    {
        builder.Property(static pic => pic.Id).HasField("_id");
        builder.Property(static pic => pic.CreatedAt).HasField("_createdAt");
        builder.Property(static pic => pic.RemovedAt).HasField("_removedAt");

        builder.HasOne(static pic => pic.Product).WithMany(static p => p.ProductInCategories);
        builder.HasOne(static pic => pic.Category).WithMany();
        
        builder.ToTable("product_in_categories");
    }
}