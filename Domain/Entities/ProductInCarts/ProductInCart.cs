using Domain.Entities.ProductInCarts.Parameters;
using Domain.Entities.Products;

namespace Domain.Entities.ProductInCarts;

public sealed class ProductInCart
{
    private Guid _id = Guid.NewGuid();

    private Product _product = default!;
    private Guid _bucketId;

    private int _quantity;
    
    private DateTimeOffset _createdAt;
    private DateTimeOffset _updatedAt;
    
    private ProductInCart()
    {
    }

    internal ProductInCart(CreateProductInCartParameters parameters) : this()
    {
        SetBucket(new SetProductInCartBucketParameters
        {
            BucketId = parameters.BucketId,
            TimeProvider = parameters.TimeProvider
        });
        
        SetProduct(new SetProductInBucketProductParameters
        {
            Product = parameters.Product,
            TimeProvider = parameters.TimeProvider
        });
        
        _createdAt = parameters.TimeProvider.GetUtcNow();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public Guid Id => _id;
    
    public Guid BucketId => _bucketId;
    public Product Product => _product;

    public int Quantity => _quantity;
    
    public DateTimeOffset CreatedAt => _createdAt;

    public DateTimeOffset UpdatedAt => _updatedAt;
    
    private void SetProduct(SetProductInBucketProductParameters parameters)
    {
        _product = parameters.Product;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    private void SetBucket(SetProductInCartBucketParameters parameters)
    {
        _bucketId = parameters.BucketId;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void AddProduct(AddProductInCartQuantityParameters parameters)
    {
        SetQuantity(new SetProductInBucketQuantityParameters
        {
            Quantity = _quantity + parameters.Quantity,
            TimeProvider = parameters.TimeProvider
        });
        
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
    
    public void RemoveProduct(RemoveProductInCartQuantityParameters parameters)
    {
        SetQuantity(new SetProductInBucketQuantityParameters
        {
            Quantity = _quantity - parameters.Quantity,
            TimeProvider = parameters.TimeProvider
        });
        
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    private void SetQuantity(SetProductInBucketQuantityParameters parameters)
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