namespace Domain.Entities.Categories.Parameters;

public readonly struct RestoreProductParameters
{
    public required TimeProvider TimeProvider { get; init; }
}