namespace Domain.Entities.ProductCharacteristics.Parameters;

public readonly struct RemoveProductCharacteristicParameters
{
    public required TimeProvider TimeProvider { get; init; }
}