namespace Domain.Categories.Entities.Products.Parameters;

public readonly struct CreateProductParameters
{
    public required string Title { get; init; }

    public required string Description { get; init; }

    public required Guid Photo { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}