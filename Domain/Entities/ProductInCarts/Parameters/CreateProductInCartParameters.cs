using Domain.Entities.Carts;
using Domain.Entities.Products;

namespace Domain.Entities.ProductInCarts.Parameters;

public readonly struct CreateProductInCartParameters
{
    public required int Quantity { get; init; }

    public required Product Product { get; init; }

    public required Cart Cart { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}