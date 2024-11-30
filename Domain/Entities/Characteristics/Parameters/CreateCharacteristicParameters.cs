namespace Domain.Entities.Characteristics.Parameters;

public readonly struct CreateCharacteristicParameters
{
    public required string Title { get; init; }
    
    public required TimeProvider TimeProvider { get; init; }
}