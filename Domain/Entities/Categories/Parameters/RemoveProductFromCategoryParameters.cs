using Domain.Entities.Products;

namespace Domain.Entities.Categories.Parameters;

public sealed class RemoveProductFromCategoryParameters
{
    public required Product Product { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}