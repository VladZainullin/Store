namespace Domain.Entities.Products.Parameters;

public readonly struct RemoveCharacteristicForProductParameters
{
    public required Guid CharacteristicId { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}