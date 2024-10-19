using Domain.Categories.Entities.Categories.Parameters;
using Domain.Categories.Entities.Products;
using Domain.Categories.Entities.Products.Parameters;

namespace Domain.Categories.Entities.Categories;

public sealed class Category
{
    private Guid _id = Guid.NewGuid();

    private string _title = default!;

    private Category? _parent;

    private readonly List<Category> _children = [];
    private readonly List<Product> _products = [];

    private DateTimeOffset _createdAt;
    private DateTimeOffset _updatedAt;

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

    public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

    public void SetTitle(SetCategoryTitleParameters parameters)
    {
        _title = parameters.Title;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void SetParent(SetCategoryParentParameters parameters)
    {
        _parent = parameters.Parent;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void AddChildren(AddCategoryChildrenParameters parameters)
    {
        _children.AddRange(parameters.Children
            .DistinctBy(static c => c.Title)
            .Select(c => new Category(new CreateCategoryParameters
            {
                Title = c.Title,
                TimeProvider = parameters.TimeProvider
            })));

        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void AddProduct(AddProductToCategoryParameters parameters)
    {
        _products.Add(new Product(new CreateProductParameters
        {
            Title = parameters.Product.Title,
            Description = parameters.Product.Description,
            TimeProvider = parameters.TimeProvider
        }));
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void RemoveProduct(RemoveProductFromCategoryParameters parameters)
    {
        _products.Remove(parameters.Product);
    }

    public void RemoveChildren(RemoveCategoryChildrenParameters parameters)
    {
        foreach (var child in parameters.Children)
        {
            _children.Remove(child);
        }
        
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
}