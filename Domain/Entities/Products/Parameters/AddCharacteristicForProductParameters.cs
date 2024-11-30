using Domain.Entities.Characteristics;
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Domain.Entities.Products.Parameters;

public readonly struct AddCharacteristicForProductParameters
{
    public required Characteristic Characteristic { get; init; }

    public required TimeProvider TimeProvider { get; init; }

    public required string Value { get; init; }
}