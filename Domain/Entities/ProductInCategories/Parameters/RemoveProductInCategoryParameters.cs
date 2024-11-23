namespace Domain.Entities.ProductInCategories.Parameters;

public readonly struct RemoveProductInCategoryParameters
{
    public required TimeProvider TimeProvider { get; init; }
}