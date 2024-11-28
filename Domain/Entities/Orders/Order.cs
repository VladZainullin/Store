using Domain.Entities.Orders.Parameters;
using Domain.Entities.ProductInOrders;
using Domain.Entities.ProductInOrders.Parameters;
using Domain.Enums.OrderStatuses;

namespace Domain.Entities.Orders;

public sealed class Order
{
    private Guid _id = Guid.CreateVersion7();

    private Guid _clientId;
    
    private DateTimeOffset _createdAt;
    private DateTimeOffset _updatedAt;

    private readonly List<ProductInOrder> _products = [];

    private OrderStatus _status = OrderStatus.Created;
    
    private Order()
    {
    }

    public Order(CreateOrderParameters parameters) : this()
    {
        SetClient(new SetClientForOrderParameters
        {
            ClientId = parameters.ClientId,
            TimeProvider = parameters.TimeProvider
        });

        foreach (var product in parameters.Products)
        {
            AddProduct(new AddProductToOrderParameters
            {
                Product = product,
                TimeProvider = parameters.TimeProvider
            });
        }
        
        _createdAt = parameters.TimeProvider.GetUtcNow();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public Guid Id => _id;
    
    public Guid ClientId => _clientId;
    
    public DateTimeOffset CreatedAt => _createdAt;
    
    public DateTimeOffset UpdatedAt => _updatedAt;
    
    public OrderStatus Status => _status;
    
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
        
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
}