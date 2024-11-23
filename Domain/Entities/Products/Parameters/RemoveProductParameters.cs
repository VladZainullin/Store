namespace Domain.Entities.Products.Parameters;

public readonly struct RemoveProductParameters
{
    public required TimeProvider TimeProvider { get; init; }
}