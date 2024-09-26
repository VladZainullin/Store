using Domain.Entities;

namespace Persistence.Contracts;

public interface IDbContext
{
    IDbSet<Vodka> Vodkas { get; }
    
    Task SaveChangesAsync(CancellationToken cancellationToken);
}