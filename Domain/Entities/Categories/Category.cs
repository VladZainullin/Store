using Domain.Entities.Categories.Parameters;
using Domain.Entities.ProductInCategories;

namespace Domain.Entities.Categories;

public sealed class Category
{
    private Guid _id = Guid.NewGuid();

    private string _title = default!;

    private List<ProductInCategory> _products = [];

    private DateTimeOffset _createdAt;
    private DateTimeOffset _updatedAt;

    private Guid _logoId = Guid.NewGuid();

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
    
    public DateTimeOffset CreatedAt => _createdAt;

    public DateTimeOffset UpdatedAt => _updatedAt;

    public Guid LogoId => _logoId;

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
    }
}