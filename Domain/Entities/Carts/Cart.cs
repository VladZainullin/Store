using Domain.Entities.Carts.Parameters;
using Domain.Entities.ProductInCarts;
using Domain.Entities.ProductInCarts.Parameters;

namespace Domain.Entities.Carts;

public sealed class Cart
{
    private Guid _id = Guid.NewGuid();

    private Guid _clientId;

    private DateTimeOffset _createdAt;
    private DateTimeOffset _updatedAt;

    private readonly List<ProductInCart> _products = [];

    private Cart()
    {
    }

    public Cart(CreateCartParameters parameters) : this()
    {
        SetClient(new SetCartClientParameters
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

    public IReadOnlyCollection<ProductInCart> Products => _products.AsReadOnly();

    private void SetClient(SetCartClientParameters parameters)
    {
        _clientId = parameters.ClientId;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void AddProduct(AddProductToCartParameters parameters)
    {
        if (_products.Count == default) return;
        
        var productInBucket = _products.SingleOrDefault(p => p.Id == parameters.ProductId);
        if (ReferenceEquals(productInBucket, default))
        {
            var newProductInBucket = new ProductInCart(new CreateProductInCartParameters
            {
                Quantity = parameters.Quantity,
                ProductId = parameters.ProductId,
                BucketId = Id,
                TimeProvider = parameters.TimeProvider
            });
            
            _products.Add(newProductInBucket);
            
            return;
        }
        
        productInBucket.AddProduct(new AddProductInCartQuantityParameters
        {
            Quantity = parameters.Quantity,
            TimeProvider = parameters.TimeProvider
        });
    }

    public void RemoveProduct(RemoveProductFromCartParameters parameters)
    {
        if (_products.Count == default) return;
        
        var productInBucket = _products.SingleOrDefault(p => p.Id == parameters.ProductId);
        if (ReferenceEquals(productInBucket, default)) return;
        
        productInBucket.RemoveProduct(new RemoveProductInCartQuantityParameters()
        {
            Quantity = parameters.Quantity,
            TimeProvider = parameters.TimeProvider
        });

        if (productInBucket.Quantity == default)
        {
            _products.Remove(productInBucket);
        }
    }

    public void Clean(CleanCartParameters parameters)
    {
        _products.Clear();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
}