using Domain.Categories.Entities.Products;

namespace Domain.Categories.Entities.Categories.Parameters;

public readonly struct RemoveProductFromCategoryParameters
{
    public required Guid ProductId { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}