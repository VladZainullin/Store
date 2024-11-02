using Domain.Entities.Orders.Parameters;
using Domain.Entities.ProductInOrders;
using Domain.Entities.ProductInOrders.Parameters;

namespace Domain.Entities.Orders;

public sealed class Order
{
    private Guid _id = Guid.NewGuid();
    
    private DateTimeOffset _createdAt;
    private DateTimeOffset _updatedAt;

    private List<ProductInOrder> _products = [];
    
    private Order()
    {
    }

    public Order(CreateOrderParameters parameters)
    {
        _createdAt = parameters.TimeProvider.GetUtcNow();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void AddProduct(AddProductToOrderParameters parameters)
    {
        var productInOrder = _products
            .SingleOrDefault(p => p.Product == parameters.Product);
        
        if (ReferenceEquals(productInOrder, default))
        {
            var newProductInOrder = new ProductInOrder(new CreateProductInOrderParameters
            {
                Product = parameters.Product,
                Order = this,
                TimeProvider = parameters.TimeProvider,
            });
            
            _products.Add(newProductInOrder);
        }
    }
}