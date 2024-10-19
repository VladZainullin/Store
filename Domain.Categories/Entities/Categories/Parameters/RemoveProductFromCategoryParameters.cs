using Domain.Categories.Entities.Products;

namespace Domain.Categories.Entities.Categories.Parameters;

public readonly struct RemoveProductFromCategoryParameters
{
    public required Product Product { get; init; }
}