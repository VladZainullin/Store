using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;

namespace Persistence;

internal sealed class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfiguration(new ProductConfiguration())
            .ApplyConfiguration(new CategoryConfiguration())
            .ApplyConfiguration(new CartConfiguration())
            .ApplyConfiguration(new ProductInCartConfiguration())
            .ApplyConfiguration(new ProductInCategoryConfiguration())
            .ApplyConfiguration(new OrderConfiguration())
            .ApplyConfiguration(new MeasurementUnitConfiguration())
            .ApplyConfiguration(new MeasurementUnitPositionConfiguration())
            .ApplyConfiguration(new ProductInOrderConfiguration())
            .ApplyConfiguration(new FavoriteProductConfiguration())
            .ApplyConfiguration(new CharacteristicConfiguration())
            .ApplyConfiguration(new ProductCharacteristicConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}