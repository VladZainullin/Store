using Domain.Entities.Products;

namespace Domain.Entities.ProductCharacteristics.Parameters;

public readonly struct SetProductForProductCharacteristicParameters
{
    public required Product Product { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}