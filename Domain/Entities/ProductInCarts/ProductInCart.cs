using Domain.Entities.Carts;
using Domain.Entities.ProductInCarts.Parameters;
using Domain.Entities.Products;

namespace Domain.Entities.ProductInCarts;

public sealed class ProductInCart
{
    private Guid _id = Guid.NewGuid();

    private Product _product = default!;

    private int _quantity;
    
    private DateTimeOffset _createdAt;
    private DateTimeOffset _updatedAt;
    private DateTimeOffset? _removedAt;
    
    private Cart _cart = default!;

    private ProductInCart()
    {
    }

    internal ProductInCart(CreateProductInCartParameters parameters) : this()
    {
        SetCart(new SetCartForProductInCartParameters
        {
            Cart = parameters.Cart,
            TimeProvider = parameters.TimeProvider
        });
        
        SetProduct(new SetProductForProductInCartParameters
        {
            Product = parameters.Product,
            TimeProvider = parameters.TimeProvider
        });
        
        _createdAt = parameters.TimeProvider.GetUtcNow();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public Guid Id => _id;
    
    public Cart Cart => _cart;
    public Product Product => _product;

    public int Quantity => _quantity;
    
    public DateTimeOffset CreatedAt => _createdAt;

    public DateTimeOffset UpdatedAt => _updatedAt;
    
    public DateTimeOffset? RemovedAt => _removedAt;
    
    public bool IsRemoved => _removedAt != default;
    
    private void SetProduct(SetProductForProductInCartParameters parameters)
    {
        _product = parameters.Product;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    private void SetCart(SetCartForProductInCartParameters parameters)
    {
        _cart = parameters.Cart;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void AddProduct(AddProductInCartQuantityParameters parameters)
    {
        SetQuantity(new SetQuantityForProductInCartParameters
        {
            Quantity = _quantity + parameters.Quantity,
            TimeProvider = parameters.TimeProvider
        });
        
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
    
    public void RemoveProduct(RemoveProductInCartQuantityParameters parameters)
    {
        SetQuantity(new SetQuantityForProductInCartParameters
        {
            Quantity = _quantity - parameters.Quantity,
            TimeProvider = parameters.TimeProvider
        });
        
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void Remove(RemoveProductInCartParameters parameters)
    {
        _removedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void Restore(RestoreProductInCartParameters parameters)
    {
        _removedAt = default;
        _createdAt = parameters.TimeProvider.GetUtcNow();
    }

    private void SetQuantity(SetQuantityForProductInCartParameters parameters)
    {
        if (parameters.Quantity < 0)
        {
            _quantity = default;
            _updatedAt = parameters.TimeProvider.GetUtcNow();
            return;
        }

        if (parameters.Quantity > _product.Quantity)
        {
            _quantity = _product.Quantity;
            _updatedAt = parameters.TimeProvider.GetUtcNow();
            return;
        }
        
        _quantity = parameters.Quantity;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
}