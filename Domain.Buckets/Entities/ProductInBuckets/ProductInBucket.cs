using Domain.Buckets.Entities.ProductInBuckets.Parameters;

namespace Domain.Buckets.Entities.ProductInBuckets;

public sealed class ProductInBucket
{
    private Guid _id = Guid.NewGuid();

    private Guid _productId;
    private Guid _bucketId;

    private int _quantity;
    
    private DateTimeOffset _createdAt;
    private DateTimeOffset _updatedAt;
    
    private ProductInBucket()
    {
    }

    internal ProductInBucket(CreateProductInBucketParameters parameters) : this()
    {
        SetBucket(new SetProductInBucketBucketParameters
        {
            BucketId = parameters.BucketId,
            TimeProvider = parameters.TimeProvider
        });
        
        SetProduct(new SetProductInBucketProductParameters
        {
            ProductId = parameters.ProductId,
            TimeProvider = parameters.TimeProvider
        });
        
        _createdAt = parameters.TimeProvider.GetUtcNow();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public Guid Id => _id;
    
    private void SetProduct(SetProductInBucketProductParameters parameters)
    {
        _productId = parameters.ProductId;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    private void SetBucket(SetProductInBucketBucketParameters parameters)
    {
        _bucketId = parameters.BucketId;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void AddProduct(AddProductInBucketQuantityParameters parameters)
    {
        _quantity = parameters.Quantity;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
    
    public void RemoveProduct(RemoveProductInBucketQuantityParameters parameters)
    {
        _quantity = parameters.Quantity;
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
        
        _quantity = parameters.Quantity;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
}