using Domain.Entities.Categories;
using Domain.Entities.Products;

namespace Domain.Entities.ProductInCategories.Parameters;

public sealed class CreateProductInCategoryParameters
{
    public required Product Product { get; init; }

    public required Category Category { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}