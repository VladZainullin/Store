using Application.Contracts.Features.Products.Commands.DeletePositionsFromProduct;
using Domain.Entities.ProductPositions;
using Domain.Entities.Products;
using Domain.Entities.Products.Parameters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Products.Commands.DeletePositionsFromProduct;

file sealed class DeletePositionsFromProductHandler(IDbContext context, TimeProvider timeProvider) : 
    IRequestHandler<DeletePositionsFromProductCommand>
{
    public async Task Handle(DeletePositionsFromProductCommand request, CancellationToken cancellationToken)
    {
        var product = await GetProductAsync(request.RouteDto.ProductId, cancellationToken);
        if (ReferenceEquals(product, default)) return;
        
        product.DeletePositions(new DeletePositionsFromProductParameters
        {
            ProductPositions = await GetProductPositionAsync(request.BodyDto.PositionIds, cancellationToken),
            TimeProvider = timeProvider
        });

        await context.SaveChangesAsync(cancellationToken);
    }

    private Task<Product?> GetProductAsync(Guid productId, CancellationToken cancellationToken)
    {
        return context.Products
            .AsTracking()
            .Where(p => p.Id == productId)
            .SingleOrDefaultAsync(cancellationToken);
    }

    private Task<List<ProductPosition>> GetProductPositionAsync(
        IEnumerable<Guid> productPositionIds,
        CancellationToken cancellationToken)
    {
        return context.ProductPositions
            .AsTracking()
            .Where(p => productPositionIds.Contains(p.Id))
            .ToListAsync(cancellationToken);
    }
}