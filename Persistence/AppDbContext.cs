using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;

namespace Persistence;

public sealed class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Vodka> Vodka => Set<Vodka>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new VodkaConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}