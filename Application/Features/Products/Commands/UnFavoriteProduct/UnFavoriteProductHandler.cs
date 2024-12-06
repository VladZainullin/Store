using Application.Contracts.Features.Products.Commands.UnFavoriteProduct;
using Application.Exceptions;
using Clients.Contracts;
using Domain.Entities.Products.Parameters;
using Mediator;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Products.Commands.UnFavoriteProduct;

internal sealed class UnFavoriteProductHandler(
    IDbContext context,
    TimeProvider timeProvider,
    ICurrentClient<Guid> currentClient) : Abstractions.IRequestHandler<UnFavoriteProductCommand>
{
    public async ValueTask Handle(UnFavoriteProductCommand request, CancellationToken cancellationToken)
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
        
        product.UnFavorite(new UnFavoriteProductParameters
        {
            ClientId = currentClient.ClientId,
            TimeProvider = timeProvider
        });

        await context.SaveChangesAsync(cancellationToken);
    }
}