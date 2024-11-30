using Domain.Entities.Characteristics;
using Domain.Entities.Products;

namespace Domain.Entities.ProductCharacteristics.Parameters;

public readonly struct CreateProductCharacteristicParameters
{
    public required Product Product { get; init; }

    public required Characteristic Characteristic { get; init; }

    public required string Value { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}