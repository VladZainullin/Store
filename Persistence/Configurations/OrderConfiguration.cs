using Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(static o => o.Id).HasField("_id");
        builder.Property(static o => o.ClientId).HasField("_clientId");
        builder.Property(static o => o.CreatedAt).HasField("_createdAt");
        builder.Property(static o => o.UpdatedAt).HasField("_updatedAt");
        
        builder.ToTable("orders");
    }
}