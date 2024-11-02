using Domain.Entities.Orders;

namespace Domain.Entities.ProductInOrders.Parameters;

public readonly struct SetProductInOrderOrderParameters
{
    public required Order Order { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}