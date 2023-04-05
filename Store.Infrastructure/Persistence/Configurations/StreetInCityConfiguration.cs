using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infrastructure.Persistence.Configurations;

internal sealed class StreetInCityConfiguration : IEntityTypeConfiguration<StreetInCity>
{
    public void Configure(EntityTypeBuilder<StreetInCity> builder)
    {
        builder.HasKey("CityId", "StreetId");
    }
}