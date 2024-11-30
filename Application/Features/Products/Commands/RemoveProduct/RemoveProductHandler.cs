using Application.Contracts.Features.Products.Commands.RemoveProduct;
using Domain.Entities.Products;
using Domain.Entities.Products.Parameters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Products.Commands.RemoveProduct;

internal sealed class RemoveProductHandler(IDbContext context, TimeProvider timeProvider) : IRequestHandler<RemoveProductCommand>
{
    public async Task Handle(RemoveProductCommand request, CancellationToken cancellationToken)
    {
        var product = await GetProductAsync(request.RouteDto.ProductId, cancellationToken);
        
        if (ReferenceEquals(product, default)) return;
        
        product.Remove(new RemoveProductParameters
        {
            TimeProvider = timeProvider
        });
        
        await context.SaveChangesAsync(cancellationToken);
    }

    private Task<Product?> GetProductAsync(Guid productId, CancellationToken cancellationToken)
    {
        return context.Products
            .AsTracking()
            .Include(static p => p.Characteristics)
            .Include(static p => p.ProductInCarts)
            .Include(static p => p.ProductInCategories)
            .Include(static p => p.ProductInOrders)
            .Include(static p => p.Favorites)
            .AsSplitQuery()
            .SingleOrDefaultAsync(p => p.Id == productId, cancellationToken);
    }
}