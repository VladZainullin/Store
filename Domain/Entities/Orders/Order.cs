using Domain.Entities.Orders.Parameters;
using Domain.Entities.ProductInOrders;
using Domain.Entities.ProductInOrders.Parameters;

namespace Domain.Entities.Orders;

public sealed class Order
{
    private Guid _id = Guid.NewGuid();

    private Guid _clientId;
    
    private DateTimeOffset _createdAt;
    private DateTimeOffset _updatedAt;

    private List<ProductInOrder> _products = [];
    
    private Order()
    {
    }

    public Order(CreateOrderParameters parameters)
    {
        SetClient(new SetClientForOrderParameters
        {
            ClientId = parameters.Cart.ClientId,
            TimeProvider = parameters.TimeProvider
        });
        
        _createdAt = parameters.TimeProvider.GetUtcNow();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public Guid Id => _id;
    
    public Guid ClientId => _clientId;
    
    public DateTimeOffset CreatedAt => _createdAt;
    
    public DateTimeOffset UpdatedAt => _updatedAt;
    
    public IReadOnlyList<ProductInOrder> Products => _products.AsReadOnly();

    public void SetClient(SetClientForOrderParameters parameters)
    {
        _clientId = parameters.ClientId;
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