using Domain.Entities.Carts;

namespace Domain.Entities.Orders.Parameters;

public sealed class CreateOrderParameters
{
    public required Cart Cart { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}