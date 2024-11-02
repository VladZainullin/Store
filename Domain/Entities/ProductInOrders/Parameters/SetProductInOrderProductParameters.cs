using Domain.Entities.Products;

namespace Domain.Entities.ProductInOrders.Parameters;

public readonly struct SetProductInOrderProductParameters
{
    public required Product Product { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}