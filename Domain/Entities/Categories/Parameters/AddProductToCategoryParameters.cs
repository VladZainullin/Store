// ReSharper disable UnusedAutoPropertyAccessor.Global

using Domain.Entities.Products;

namespace Domain.Entities.Categories.Parameters;

public readonly struct AddProductToCategoryParameters
{
    public required Product Product { get; init; }
    
    public required TimeProvider TimeProvider { get; init; }
}