using Domain.Entities.Products;

namespace Domain.Entities.ProductPositions.Parameters;

public readonly struct CreateProductPositionParameters
{
    public required Product Product { get; init; }

    public required Guid MeasurementUnitPositionId { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}