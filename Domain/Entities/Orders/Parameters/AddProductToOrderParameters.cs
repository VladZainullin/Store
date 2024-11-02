using Domain.Entities.Products;

namespace Domain.Entities.Orders.Parameters;

public readonly struct AddProductToOrderParameters
{
    public required Product Product { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}