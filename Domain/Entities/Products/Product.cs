using Domain.Entities.Products.Exceptions;
using Domain.Entities.Products.Parameters;

namespace Domain.Entities.Products;

public sealed class Product
{
    private Guid _id = Guid.NewGuid();
    
    private string _title = default!;
    private string _description = default!;
    
    private Guid _photo = Guid.NewGuid();
    
    private DateTimeOffset _updatedAt;
    private DateTimeOffset _createdAt;
    private DateTimeOffset? _removedAt;

    private int _quantity;

    private decimal _cost;

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

    public void SetTitle(SetProductTitleParameters parameters)
    {
        if (IsRemoved) throw new SetTitleForRemovedProductException();

        if (parameters.Title == string.Empty) throw new SetWhiteSpacesTitleForProductException();
        
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
    }

    public void Restore(RestoreProductParameters parameters)
    {
        if (!IsRemoved) return;
        
        _removedAt = default;
        _createdAt = parameters.TimeProvider.GetUtcNow();
    }
}