using Domain.Orders.Entities.Orders.Parameters;
using Domain.Orders.Enums;

namespace Domain.Orders.Entities.Orders;

public sealed class Order
{
    private Guid _id = Guid.NewGuid();
    
    private DateTimeOffset _createdAt;
    private DateTimeOffset _updatedAt;

    private OrderStatus _status = default!;
    
    private Order()
    {
    }

    public Order(CreateOrderParameters parameters) : this()
    {
        _status = OrderStatus.New;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
        _createdAt = parameters.TimeProvider.GetUtcNow();
    }
}