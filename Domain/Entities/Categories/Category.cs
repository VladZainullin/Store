using Domain.Entities.Categories.Exceptions;
using Domain.Entities.Categories.Parameters;
using Domain.Entities.ProductInCategories;
using Domain.Entities.ProductInCategories.Parameters;
using EntityFrameworkCore.Projectables;

namespace Domain.Entities.Categories;

public sealed class Category
{
    private Guid _id = Guid.CreateVersion7();

    private string _title = default!;
    
    private Guid _logoId = Guid.CreateVersion7();

    private DateTimeOffset _createdAt;
    private DateTimeOffset _updatedAt;
    private DateTimeOffset? _removedAt;
    
    private List<ProductInCategory> _products = [];

    private Category()
    {
    }

    public Category(CreateCategoryParameters parameters) : this()
    {
        SetTitle(new SetCategoryTitleParameters
        {
            Title = parameters.Title,
            TimeProvider = parameters.TimeProvider
        });

        _createdAt = parameters.TimeProvider.GetUtcNow();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public Guid Id => _id;

    public string Title => _title;
    
    public Guid LogoId => _logoId;
    
    public DateTimeOffset CreatedAt => _createdAt;

    public DateTimeOffset UpdatedAt => _updatedAt;
    
    public DateTimeOffset? RemovedAt => _removedAt;

    [Projectable]
    public bool IsRemoved => RemovedAt != default;
    
    public IReadOnlyList<ProductInCategory> Products => _products.AsReadOnly();

    public void Remove(RemoveCategoryParameters parameters)
    {
        if (IsRemoved) return;
        
        _removedAt = parameters.TimeProvider.GetUtcNow();

        foreach (var product in _products)
        {
            product.Remove(new RemoveProductInCategoryParameters
            {
                TimeProvider = parameters.TimeProvider
            });
        }
    }

    public void Restore(RestoreCategoryParameters parameters)
    {
        if (!IsRemoved) return;

        _removedAt = default;
        _createdAt = parameters.TimeProvider.GetUtcNow();
    }

    public void SetTitle(SetCategoryTitleParameters parameters)
    {
        if (_title == parameters.Title)
        {
            return;
        }
        
        _title = parameters.Title;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void AddProduct(AddProductToCategoryParameters parameters)
    {
        if (IsRemoved) throw new AddProductToRemovedCategoryException();

        if (parameters.Product.IsRemoved) throw new AddRemovedProductToCategoryException();
        
        var productInCategory = _products.SingleOrDefault(p => p.Product == parameters.Product);
        if (!ReferenceEquals(productInCategory, default))
        {
            productInCategory.Restore(new RestoreProductInCategoryParameters
            {
                TimeProvider = parameters.TimeProvider
            });
        }

        var newProductInCategory = new ProductInCategory(new CreateProductInCategoryParameters
        {
            Product = parameters.Product,
            Category = this,
            TimeProvider = parameters.TimeProvider
        });
        
        _products.Add(newProductInCategory);

        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void RemoveProduct(RemoveProductFromCategoryParameters parameters)
    {
        if (IsRemoved) throw new RemoveProductFromRemovedCategoryException();

        if (parameters.Product.IsRemoved) throw new RemoveRemovedProductFromCategoryException();
        
        var productInCategory = _products.SingleOrDefault(p => p.Product == parameters.Product);

        if (ReferenceEquals(productInCategory, default)) return;
        
        productInCategory.Remove(new RemoveProductInCategoryParameters
        {
            TimeProvider = parameters.TimeProvider
        });
    }
}