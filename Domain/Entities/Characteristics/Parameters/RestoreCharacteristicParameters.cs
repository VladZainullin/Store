namespace Domain.Entities.Characteristics.Parameters;

public readonly struct RestoreCharacteristicParameters
{
    public required TimeProvider TimeProvider { get; init; }
}