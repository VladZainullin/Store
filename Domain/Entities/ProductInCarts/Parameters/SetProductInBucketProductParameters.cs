// ReSharper disable UnusedAutoPropertyAccessor.Global

using Domain.Entities.Products;

namespace Domain.Entities.ProductInCarts.Parameters;

public readonly struct SetProductInBucketProductParameters
{
    public required Product Product { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}