using Domain.Entities.VodkaPositions;
using Domain.Entities.Vodkas;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;

namespace Persistence;

public sealed class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Vodka> Vodka => Set<Vodka>();

    public DbSet<VodkaPosition> VodkaPositions => Set<VodkaPosition>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new VodkaConfiguration());
        modelBuilder.ApplyConfiguration(new VodkaPositionConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}