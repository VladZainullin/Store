namespace Domain.Entities.ProductCharacteristics.Parameters;

public readonly struct RestoreProductCharacteristicParameters
{
    public required TimeProvider TimeProvider { get; init; }
}