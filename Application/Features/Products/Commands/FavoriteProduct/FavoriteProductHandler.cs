using Application.Contracts.Features.Products.Commands.FavoriteProduct;
using Application.Exceptions;
using Clients.Contracts;
using Domain.Entities.Products.Parameters;
using Mediator;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Products.Commands.FavoriteProduct;

internal sealed class FavoriteProductHandler(
    IDbContext context,
    TimeProvider timeProvider,
    ICurrentClient<Guid> currentClient) : Abstractions.IRequestHandler<FavoriteProductCommand>
{
    public async ValueTask Handle(
        FavoriteProductCommand request,
        CancellationToken cancellationToken)
    {
        var product = await context.Products
            .AsTracking()
            .Include(p => p.Favorites
                .Where(fp => fp.ClientId == currentClient.ClientId))
            .SingleOrDefaultAsync(p => p.Id == request.Route.ProductId, cancellationToken);

        if (ReferenceEquals(product, default))
        {
            throw new ProductNotFoundException();
        }
        
        product.Favorite(new FavoriteProductParameters
        {
            ClientId = currentClient.ClientId,
            TimeProvider = timeProvider
        });

        await context.SaveChangesAsync(cancellationToken);
    }
}