namespace Domain.Entities.Products.Parameters;

public readonly struct RestoreProductParameters
{
    public required TimeProvider TimeProvider { get; init; }
}