using Domain.Entities.Orders;
using Domain.Entities.Products;

namespace Domain.Entities.ProductInOrders.Parameters;

public readonly struct CreateProductInOrderParameters
{
    public required Product Product { get; init; }

    public required Order Order { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}