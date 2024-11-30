using Domain.Entities.FavoriteProducts;
using Domain.Entities.FavoriteProducts.Parameters;
using Domain.Entities.ProductCharacteristics;
using Domain.Entities.ProductCharacteristics.Parameters;
using Domain.Entities.ProductInCarts;
using Domain.Entities.ProductInCarts.Parameters;
using Domain.Entities.ProductInCategories;
using Domain.Entities.ProductInCategories.Parameters;
using Domain.Entities.ProductInOrders;
using Domain.Entities.ProductInOrders.Parameters;
using Domain.Entities.Products.Exceptions;
using Domain.Entities.Products.Parameters;

namespace Domain.Entities.Products;

public sealed class Product
{
    private Guid _id = Guid.CreateVersion7();
    
    private string _title = default!;
    private string _description = default!;
    
    private Guid _photo = Guid.NewGuid();
    
    private DateTimeOffset _updatedAt;
    private DateTimeOffset _createdAt;
    private DateTimeOffset? _removedAt;

    private int _quantity;

    private decimal _cost;
    
    private readonly List<ProductInCart> _productInCarts = [];
    
    private readonly List<ProductInOrder> _productInOrders = [];
    
    private readonly List<ProductInCategory> _productInCategories = [];

    private readonly List<FavoriteProduct> _favorites = [];
    
    private readonly List<ProductCharacteristic> _characteristics = [];

    private Product()
    {
    }

    public Product(CreateProductParameters parameters) : this()
    {
        SetTitle(new SetProductTitleParameters
        {
            Title = parameters.Title,
            TimeProvider = parameters.TimeProvider
        });
        
        SetDescription(new SetProductDescriptionParameters
        {
            Description = parameters.Description,
            TimeProvider = parameters.TimeProvider
        });
        
        SetQuantity(new SetProductQuantityParameters
        {
            Quantity = parameters.Quantity,
            TimeProvider = parameters.TimeProvider
        });
        
        SetCost(new SetProductCostParameters
        {
            Cost = parameters.Cost,
            TimeProvider = parameters.TimeProvider
        });
        
        UpdatePhoto(new SetProductPhotoParameters
        {
            TimeProvider = parameters.TimeProvider
        });

        _createdAt = parameters.TimeProvider.GetUtcNow();
    }

    public Guid Id => _id;

    public string Title => _title;
    
    public string Description => _description;

    public Guid Photo => _photo;
    
    public DateTimeOffset CreatedAt => _createdAt;
    
    public DateTimeOffset UpdatedAt => _updatedAt;
    
    public DateTimeOffset? RemovedAt => _removedAt;
    
    public bool IsRemoved => _removedAt != default;

    public int Quantity => _quantity;
    
    public decimal Cost => _cost;
    
    public IReadOnlyList<FavoriteProduct> Favorites => _favorites.AsReadOnly();
    
    public IReadOnlyList<ProductInCart> ProductInCarts => _productInCarts.AsReadOnly();
    
    public IReadOnlyList<ProductInOrder> ProductInOrders => _productInOrders.AsReadOnly();
    
    public IReadOnlyList<ProductInCategory> ProductInCategories => _productInCategories.AsReadOnly();
    
    public IReadOnlyCollection<ProductCharacteristic> Characteristics => _characteristics.AsReadOnly();

    public void SetTitle(SetProductTitleParameters parameters)
    {
        if (IsRemoved) throw new SetTitleForRemovedProductException();

        if (parameters.Title == string.Empty) throw new SetEmptyTitleForProductException();
        
        var trimmedTitle = parameters.Title.Trim();
        if (trimmedTitle == string.Empty) throw new SetWhiteSpacesTitleForProductException();
        
        if (trimmedTitle.Length > 200) throw new SetMoreThanMaxLenghtTitleForProductException();
        
        if (trimmedTitle == Title) return;
        
        _title = trimmedTitle;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void SetDescription(SetProductDescriptionParameters parameters)
    {
        if (IsRemoved) throw new SetDescriptionForRemovedProductException();
        
        if (parameters.Description == string.Empty) throw new SetEmptyDescriptionForProductException();
        
        var trimmedDescription = parameters.Description.Trim();
        if (trimmedDescription == string.Empty) throw new SetWhiteSpacesDescriptionForProductException();
        
        if (trimmedDescription.Length > 6000) throw new SetMoreThanMaxLenghtDescriptionForProductException();
        
        if (trimmedDescription == Description) return;
        
        _description = parameters.Description.Trim();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void SetQuantity(SetProductQuantityParameters parameters)
    {
        if (parameters.Quantity < 0) throw new SetLessThanZeroQuantityForProductException();
        
        if (parameters.Quantity == Quantity) return;
        
        _quantity = parameters.Quantity;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void SetCost(SetProductCostParameters parameters)
    {
        if (IsRemoved) throw new SetCostForRemovedProductException();
        
        if (parameters.Cost <= 0) throw new SetLessOrEqualZeroCostForProductException();
        
        if (parameters.Cost == Cost) return;
        
        _cost = parameters.Cost;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void UpdatePhoto(SetProductPhotoParameters parameters)
    {
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void Remove(RemoveProductParameters parameters)
    {
        if (IsRemoved) return;
        
        _removedAt = parameters.TimeProvider.GetUtcNow();

        foreach (var productInCategory in _productInCategories)
        {
            productInCategory.Remove(new RemoveProductInCategoryParameters
            {
                TimeProvider = parameters.TimeProvider,
            });
        }

        foreach (var productInOrder in _productInOrders)
        {
            productInOrder.Remove(new RemoveProductInOrderParameters
            {
                TimeProvider = parameters.TimeProvider,
            });
        }

        foreach (var productInCart in _productInCarts)
        {
            productInCart.Remove(new RemoveProductInCartParameters
            {
                TimeProvider = parameters.TimeProvider,
            });
        }

        foreach (var favorite in _favorites)
        {
            favorite.Remove(new RemoveFavoriteProductParameters
            {
                TimeProvider = parameters.TimeProvider,
            });
        }

        foreach (var productCharacteristic in _characteristics)
        {
            productCharacteristic.Remove(new RemoveProductCharacteristicParameters
            {
                TimeProvider = parameters.TimeProvider
            });
        }
    }

    public void Restore(RestoreProductParameters parameters)
    {
        if (!IsRemoved) return;
        
        _removedAt = default;
        _createdAt = parameters.TimeProvider.GetUtcNow();
    }

    public FavoriteProduct Favorite(FavoriteProductParameters parameters)
    {
        if (IsRemoved) throw new FavoriteRemovedProductException();
        
        var favorite = _favorites.SingleOrDefault(f => f.ClientId == parameters.ClientId);
        if (!ReferenceEquals(favorite, default))
        {
            if (favorite.IsRemoved)
            {
                favorite.Restore(new RestoreFavoriteProductParameters
                {
                    TimeProvider = parameters.TimeProvider
                });
            }

            return favorite;
        }

        var newFavorite = new FavoriteProduct(new CreateFavoriteProductParameters
        {
            Product = this,
            ClientId = parameters.ClientId,
            TimeProvider = parameters.TimeProvider
        });
        
        _favorites.Add(newFavorite);
        
        return newFavorite;
    }

    public void UnFavorite(UnFavoriteProductParameters parameters)
    {
        if (IsRemoved) return;
        
        var favorite = _favorites.SingleOrDefault(f => f.ClientId == parameters.ClientId);
        favorite?.Remove(new RemoveFavoriteProductParameters
        {
            TimeProvider = parameters.TimeProvider
        });
    }

    public void AddCharacteristic(AddCharacteristicForProductParameters parameters)
    {
        if (IsRemoved) return;

        var characteristic = _characteristics
            .SingleOrDefault(pc => pc.Characteristic == parameters.Characteristic);
        if (!ReferenceEquals(characteristic, default))
        {
            if (characteristic.IsRemoved)
            {
                characteristic.Restore(new RestoreProductCharacteristicParameters
                {
                    TimeProvider = parameters.TimeProvider
                });
            }
            
            return;
        }

        var newCharacteristic = new ProductCharacteristic(new CreateProductCharacteristicParameters
        {
            Product = this,
            Characteristic = parameters.Characteristic,
            TimeProvider = parameters.TimeProvider,
            Value = parameters.Value
        });
        
        _characteristics.Add(newCharacteristic);
    }

    public void RemoveCharacteristic(RemoveCharacteristicForProductParameters parameters)
    {
        if (IsRemoved) return;
        
        var characteristic = _characteristics
            .SingleOrDefault(pc => pc.Characteristic.Id == parameters.CharacteristicId);
        if (ReferenceEquals(characteristic, default)) return;
        
        characteristic.Remove(new RemoveProductCharacteristicParameters
        {
            TimeProvider = parameters.TimeProvider
        });
    }
}