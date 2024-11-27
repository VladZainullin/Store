using Domain.Entities.Products;

namespace Domain.Entities.Orders.Parameters;

public sealed class CreateOrderParameters
{
    public required Guid ClientId { get; init; }

    public required IEnumerable<Product> Products { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}