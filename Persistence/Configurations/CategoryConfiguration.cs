using Domain.Categories.Entities.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(static c => c.Id).HasField("_id").ValueGeneratedNever();
        builder.Property(static c => c.Title).HasField("_title");
        builder.Property(static c => c.UpdatedAt).HasField("_updatedAt");
        builder.Property(static c => c.CreatedAt).HasField("_createdAt");
        builder.HasIndex(static c => c.Title).IsUnique();

        builder.HasMany(static c => c.Products).WithOne();
        builder.HasMany(static c => c.Children).WithOne(static c => c.Parent);
    }
}