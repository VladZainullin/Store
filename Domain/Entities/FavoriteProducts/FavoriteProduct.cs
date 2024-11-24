using Domain.Entities.FavoriteProducts.Parameters;
using Domain.Entities.Products;

namespace Domain.Entities.FavoriteProducts;

public sealed class FavoriteProduct
{
    private Guid _id = Guid.NewGuid();
    
    private Guid _clientId;

    private Product _product = default!;
    
    private DateTimeOffset _createdAt;
    private DateTimeOffset _updatedAt;
    private DateTimeOffset? _removedAt;
    
    private FavoriteProduct()
    {
    }

    public FavoriteProduct(CreateFavoriteProductParameters parameters) : this()
    {
        SetProduct(new SetProductForFavoriteProductParameters
        {
            Product = parameters.Product,
            TimeProvider = parameters.TimeProvider
        });
        
        SetClient(new SetClientForFavoriteProductParameters
        {
            ClientId = parameters.ClientId,
            TimeProvider = parameters.TimeProvider
        });
        
        _createdAt = parameters.TimeProvider.GetUtcNow();
    }

    public Guid Id => _id;
    
    public Guid ClientId => _clientId;

    public Product Product => _product;
    
    public DateTimeOffset CreatedAt => _createdAt;
    
    public DateTimeOffset UpdatedAt => _updatedAt;
    
    public DateTimeOffset? RemovedAt => _removedAt;

    public bool IsRemoved => _removedAt != default;

    public void Remove(RemoveFavoriteProductParameters parameters)
    {
        if (IsRemoved) return;
        
        _removedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void Restore(RestoreFavoriteProductParameters parameters)
    {
        if (!IsRemoved) return;
        
        _removedAt = default;
        _createdAt = parameters.TimeProvider.GetUtcNow();
    }
    
    public void SetProduct(SetProductForFavoriteProductParameters parameters)
    {
        _product = parameters.Product;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void SetClient(SetClientForFavoriteProductParameters parameters)
    {
        _clientId = parameters.ClientId;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
}