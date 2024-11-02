using Application.Contracts.Features.Carts.Commands.RemoveProductFromCart;
using Clients.Contracts;
using Domain.Entities.Carts.Parameters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Carts.Commands.RemoveProductFromBucket;

internal sealed class RemoveProductFromBucketHandler(
    IDbContext context,
    ICurrentClient<Guid> currentClient,
    TimeProvider timeProvider) : 
    IRequestHandler<RemoveProductFromCartCommand>
{
    public async Task Handle(RemoveProductFromCartCommand request, CancellationToken cancellationToken)
    {
        var cart = await context.Carts
            .AsTracking()
            .Include(static c => c.Products)
            .SingleOrDefaultAsync(c => c.ClientId == currentClient.ClientId, cancellationToken);
        if (ReferenceEquals(cart, default)) return;
        
        cart.RemoveProduct(new RemoveProductFromCartParameters
        {
            ProductId = request.RouteDto.ProductId,
            Quantity = request.BodyDto.Quantity,
            TimeProvider = timeProvider
        });

        await context.SaveChangesAsync(cancellationToken);
    }
}