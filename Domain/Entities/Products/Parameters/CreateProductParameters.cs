namespace Domain.Entities.Products.Parameters;

public sealed class CreateProductParameters
{
    public required string Title { get; init; }

    public required string Description { get; init; }

    public required int Quantity { get; init; }

    public required decimal Cost { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}