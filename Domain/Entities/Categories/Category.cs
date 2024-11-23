using Domain.Entities.Categories.Parameters;
using Domain.Entities.ProductInCategories;
using Domain.Entities.ProductInCategories.Parameters;
using RemoveProductParameters = Domain.Entities.Products.Parameters.RemoveProductParameters;

namespace Domain.Entities.Categories;

public sealed class Category
{
    private Guid _id = Guid.NewGuid();

    private string _title = default!;
    
    private Guid _logoId = Guid.NewGuid();

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

    public bool IsRemoved => _removedAt != default;

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
        var productInCategory = _products.SingleOrDefault(p => p.Product == parameters.Product);
        if (!ReferenceEquals(productInCategory, default))
        {
            productInCategory.Restore(new RestoreProductInCategoryParameters
            {
                TimeProvider = parameters.TimeProvider
            });
            
            return;
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
}