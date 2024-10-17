using Domain.Entities.Products;

namespace Domain.Entities.ProductPositions.Parameters;

public readonly struct SetProductPositionProductParameters
{
    public required Product Product { get; init; }
    
    public required TimeProvider TimeProvider { get; init; }
}