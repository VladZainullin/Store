namespace Domain.Entities.Characteristics.Parameters;

public readonly struct RemoveCharacteristicParameters
{
    public required TimeProvider TimeProvider { get; init; }
}