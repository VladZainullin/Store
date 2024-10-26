using Domain.Entities.Buckets.Parameters;
using Domain.Entities.ProductInBuckets;
using Domain.Entities.ProductInBuckets.Parameters;

namespace Domain.Entities.Buckets;

public sealed class Bucket
{
    private Guid _id = Guid.NewGuid();

    private Guid _clientId;

    private DateTimeOffset _createdAt;
    private DateTimeOffset _updatedAt;

    private readonly List<ProductInBucket> _products = [];

    private Bucket()
    {
    }

    public Bucket(CreateBucketParameters parameters) : this()
    {
        SetClient(new SetBucketClientParameters
        {
            ClientId = parameters.ClientId,
            TimeProvider = parameters.TimeProvider
        });

        _createdAt = parameters.TimeProvider.GetUtcNow();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public Guid Id => _id;

    public Guid ClientId => _clientId;

    public DateTimeOffset CreatedAt => _createdAt;

    public DateTimeOffset UpdatedAt => _updatedAt;

    public IReadOnlyCollection<ProductInBucket> Products => _products.AsReadOnly();

    private void SetClient(SetBucketClientParameters parameters)
    {
        _clientId = parameters.ClientId;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void AddProduct(AddProductToBucketParameters parameters)
    {
        if (_products.Count == default) return;
        
        var productInBucket = _products.SingleOrDefault(p => p.Id == parameters.ProductId);
        if (ReferenceEquals(productInBucket, default))
        {
            var newProductInBucket = new ProductInBucket(new CreateProductInBucketParameters
            {
                Quantity = parameters.Quantity,
                ProductId = parameters.ProductId,
                BucketId = Id,
                TimeProvider = parameters.TimeProvider
            });
            
            _products.Add(newProductInBucket);
            
            return;
        }
        
        productInBucket.AddProduct(new AddProductInBucketQuantityParameters
        {
            Quantity = parameters.Quantity,
            TimeProvider = parameters.TimeProvider
        });
    }

    public void RemoveProduct(RemoveProductFromBucketParameters parameters)
    {
        if (_products.Count == default) return;
        
        var productInBucket = _products.SingleOrDefault(p => p.Id == parameters.ProductId);
        if (ReferenceEquals(productInBucket, default)) return;
        
        productInBucket.RemoveProduct(new RemoveProductInBucketQuantityParameters()
        {
            Quantity = parameters.Quantity,
            TimeProvider = parameters.TimeProvider
        });

        if (productInBucket.Quantity == default)
        {
            _products.Remove(productInBucket);
        }
    }

    public void Clean(CleanBucketParameters parameters)
    {
        _products.Clear();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
}