using Domain.Entities.Orders;
using Domain.Entities.ProductInOrders.Parameters;
using Domain.Entities.Products;

namespace Domain.Entities.ProductInOrders;

public sealed class ProductInOrder
{
    private Guid _id = Guid.NewGuid();

    private int _quantity = 1;
    private decimal _cost = default!;
    
    private Product _product = default!;
    private Order _order = default!;

    private DateTimeOffset _createdAt;
    private DateTimeOffset _updatedAt;
    
    private ProductInOrder()
    {
    }

    public ProductInOrder(CreateProductInOrderParameters parameters)
    {
        SetProduct(new SetProductInOrderProductParameters
        {
            Product = parameters.Product,
            TimeProvider = parameters.TimeProvider
        });
        
        SetOrder(new SetProductInOrderOrderParameters()
        {
            Order = parameters.Order,
            TimeProvider = parameters.TimeProvider
        });
        
        _createdAt = parameters.TimeProvider.GetUtcNow();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public Guid Id => _id;

    public Product Product => _product;
    
    public Order Order => _order;

    public int Quantity => _quantity;
    
    public decimal Cost => _cost;

    public DateTimeOffset CreatedAt => _createdAt;

    public DateTimeOffset UpdatedAt => _updatedAt;

    public void SetOrder(SetProductInOrderOrderParameters parameters)
    {
        _order = parameters.Order;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
    
    public void SetProduct(SetProductInOrderProductParameters parameters)
    {
        _product = parameters.Product;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void IncrementProduct(IncrementProductInOrderProductQuantityParameters parameters)
    {
        if (_product.Quantity == _quantity)
        {
            return;
        }
        
        _quantity += 1;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
    
    public void DecrementProduct(DecrementProductInOrderProductQuantityParameters parameters)
    {
        if (_quantity == 0)
        {
            return;
        }
        
        _quantity -= 1;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
}