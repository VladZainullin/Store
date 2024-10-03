using Domain.Entities.ProductPositions;

namespace Domain.Entities.Products.Parameters;

public sealed class DeletePositionsFromProductParameters
{
    public required IEnumerable<ProductPosition> ProductPositions { get; init; }
    
    public required TimeProvider TimeProvider { get; init; }
}