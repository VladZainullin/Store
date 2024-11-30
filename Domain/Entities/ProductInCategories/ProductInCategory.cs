using Domain.Entities.Categories;
using Domain.Entities.ProductInCategories.Parameters;
using Domain.Entities.Products;

namespace Domain.Entities.ProductInCategories;

public sealed class ProductInCategory
{
    private Guid _id = Guid.CreateVersion7();
    
    private Product _product = default!;
    private Category _category = default!;
    
    private DateTimeOffset _createdAt;
    private DateTimeOffset? _removedAt;
    
    private ProductInCategory()
    {
    }

    public ProductInCategory(CreateProductInCategoryParameters parameters) : this()
    {
        _product = parameters.Product;
        _category = parameters.Category;

        _createdAt = parameters.TimeProvider.GetUtcNow();
    }

    public Guid Id => _id;
    
    public Product Product => _product;

    public Category Category => _category;
    
    public DateTimeOffset CreatedAt => _createdAt;
    
    public DateTimeOffset? RemovedAt => _removedAt;
    
    public bool IsRemoved => RemovedAt != default;

    public void Remove(RemoveProductInCategoryParameters parameters)
    {
        if (IsRemoved) return;
        
        _removedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void Restore(RestoreProductInCategoryParameters parameters)
    {
        if (!IsRemoved) return;
        
        _removedAt = default;
        _createdAt = parameters.TimeProvider.GetUtcNow();
    }
}