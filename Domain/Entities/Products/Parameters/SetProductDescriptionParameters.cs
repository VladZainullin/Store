namespace Domain.Entities.Products.Parameters;

public readonly struct SetProductDescriptionParameters
{
    public required string Description { get; init; }
}