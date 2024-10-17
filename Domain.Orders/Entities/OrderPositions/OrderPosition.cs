using Domain.Orders.Entities.OrderPositions.Parameters;
using Domain.Orders.Entities.Orders;

namespace Domain.Orders.Entities.OrderPositions;

public sealed class OrderPosition
{
    private Guid _id = Guid.NewGuid();
    
    private Order _order = default!;
    private Guid _productId;

    private DateTimeOffset _createdAt;
    private DateTimeOffset _updatedAt;
    
    private OrderPosition()
    {
    }

    public OrderPosition(CreateOrderPositionParameters parameters)
    {
        SetProduct(new SetOrderPositionProductParameters
        {
            ProductId = parameters.ProductId,
            TimeProvider = parameters.TimeProvider
        });
        
        SetOrder(new SetOrderPositionOrderParameters
        {
            Order = parameters.Order,
            TimeProvider = parameters.TimeProvider
        });

        _createdAt = parameters.TimeProvider.GetUtcNow();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void SetOrder(SetOrderPositionOrderParameters parameters)
    {
        _order = parameters.Order;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void SetProduct(SetOrderPositionProductParameters parameters)
    {
        _productId = parameters.ProductId;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
}