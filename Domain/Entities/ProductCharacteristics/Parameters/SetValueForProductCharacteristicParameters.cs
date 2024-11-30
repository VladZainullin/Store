namespace Domain.Entities.ProductCharacteristics.Parameters;

public readonly struct SetValueForProductCharacteristicParameters
{
    public required string Value { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}