using Application.Contracts.Features.Products.Commands.RestoreProduct;
using Application.Exceptions;
using Domain.Entities.Products;
using Domain.Entities.Products.Parameters;
using Mediator;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Products.Commands.RestoreProduct;

internal sealed class RestoreProductHandler(IDbContext context, TimeProvider timeProvider) : Abstractions.IRequestHandler<RestoreProductCommand>
{
    public async ValueTask Handle(RestoreProductCommand request, CancellationToken cancellationToken)
    {
        var product = await GetProductAsnc(request.Route.ProductId, cancellationToken);

        if (ReferenceEquals(product, default))
        {
            throw new ProductNotFoundException();
        }
        
        product.Restore(new RestoreProductParameters
        {
            TimeProvider = timeProvider
        });
        
        await context.SaveChangesAsync(cancellationToken);
    }

    private Task<Product?> GetProductAsnc(Guid productId, CancellationToken cancellationToken)
    {
        return context.Products
            .AsTracking()
            .SingleOrDefaultAsync(p => p.Id == productId, cancellationToken);
    }
}