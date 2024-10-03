using Domain.Entities.Products;

namespace Domain.Entities.ProductPositions.Parameters;

public readonly struct SetProductPositionVodkaParameters
{
    public required Product Product { get; init; }
}