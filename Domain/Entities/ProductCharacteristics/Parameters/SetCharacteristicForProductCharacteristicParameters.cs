using Domain.Entities.Characteristics;

namespace Domain.Entities.ProductCharacteristics.Parameters;

public readonly struct SetCharacteristicForProductCharacteristicParameters
{
    public required Characteristic Characteristic { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}