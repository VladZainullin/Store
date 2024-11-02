using Application.Contracts.Features.Carts.Commands.CleanCart;
using Clients.Contracts;
using Domain.Entities.Carts.Parameters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Carts.Commands.CleanBucket;

internal sealed class CleanBucketHandler(
    IDbContext context,
    ICurrentClient<Guid> currentClient,
    TimeProvider timeProvider) : IRequestHandler<CleanCartCommand>
{
    public async Task Handle(CleanCartCommand request, CancellationToken cancellationToken)
    {
        var cart = await context.Carts
            .AsTracking()
            .Include(static c => c.Products)
            .SingleOrDefaultAsync(c => c.ClientId == currentClient.ClientId, cancellationToken);
        
        if (ReferenceEquals(cart, default)) return;

        cart.Clean(new CleanCartParameters
        {
            TimeProvider = timeProvider
        });

        await context.SaveChangesAsync(cancellationToken);
    }
}