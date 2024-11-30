namespace Domain.Entities.Characteristics.Parameters;

public readonly struct SetTitleForCharacteristicParameters
{
    public required string Title { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}