// ReSharper disable UnusedAutoPropertyAccessor.Global

using Domain.Entities.Carts;

namespace Domain.Entities.ProductInCarts.Parameters;

public readonly struct SetCartForProductInCartParameters
{
    public required Cart Cart { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}