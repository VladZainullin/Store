using Application.Contracts.Features.Products.Commands.AddPositionsToProduct;
using Domain.Entities.Products;
using Domain.Entities.Products.Parameters;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Application.Features.Products.Commands.AddPositionsToProduct;

file sealed class AddPositionsToProductHandler(IDbContext context, TimeProvider timeProvider) : IRequestHandler<AddPositionsToProductCommand>
{
    public async Task Handle(AddPositionsToProductCommand request, CancellationToken cancellationToken)
    {
        var product = await GetProductAsync(request.RouteDto.ProductId, cancellationToken);
        if (ReferenceEquals(product, default)) return;
        
        product.AddPositions(new AddPositionsToProductParameters
        {
            Positions = request.BodyDto.Positions.Select(static p => new AddPositionsToProductParameters.PositionDto
            {
                MeasurementUnitPositionId = p.MeasurementUnitPositionId
            }),
            TimeProvider = timeProvider
        });

        await context.SaveChangesAsync(cancellationToken);
    }

    private Task<Product?> GetProductAsync(Guid productId, CancellationToken cancellationToken)
    {
        return context.Products
            .AsTracking()
            .SingleOrDefaultAsync(p => p.Id == productId, cancellationToken);
    }
}