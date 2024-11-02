// ReSharper disable UnusedAutoPropertyAccessor.Global

using Domain.Entities.Products;

namespace Domain.Entities.Carts.Parameters;

public readonly struct AddProductToCartParameters
{
    public required Product Product { get; init; }

    public required int Quantity { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}