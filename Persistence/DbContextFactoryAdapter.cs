using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Persistence;

internal sealed class DbContextFactoryAdapter(IDbContextFactory<AppDbContext> factory) : IDbContextFactory
{
    public async Task<IDbContext> CreateAsync(CancellationToken cancellationToken = default)
    {
        var context = await factory.CreateDbContextAsync(cancellationToken);
        return new DbContextAdapter(context);
    }

    public IDbContext Create()
    {
        var context = factory.CreateDbContext();
        return new DbContextAdapter(context);
    }
}