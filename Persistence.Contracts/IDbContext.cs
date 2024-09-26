using Domain.Entities;
using Domain.Entities.Vodkas;

namespace Persistence.Contracts;

public interface IDbContext
{
    IDbSet<Vodka> Vodkas { get; }
    
    Task SaveChangesAsync(CancellationToken cancellationToken);
}