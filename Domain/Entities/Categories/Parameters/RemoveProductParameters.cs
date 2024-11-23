namespace Domain.Entities.Categories.Parameters;

public readonly struct RemoveProductParameters
{
    public required TimeProvider TimeProvider { get; init; }
}