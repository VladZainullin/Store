namespace Domain.Categories.Entities.Products.Parameters;

public readonly struct SetProductCostParameters
{
    public decimal Cost { get; init; }

    public TimeProvider TimeProvider { get; init; }
}