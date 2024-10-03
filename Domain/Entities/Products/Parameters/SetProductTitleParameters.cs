namespace Domain.Entities.Products.Parameters;

public readonly struct SetProductTitleParameters
{
    public required string Title { get; init; }
}