using Domain.Entities.Characteristics;

namespace Domain.Entities.Products.Parameters;

public readonly struct AddCharacteristicForProductParameters
{
    public required Characteristic Characteristic { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}