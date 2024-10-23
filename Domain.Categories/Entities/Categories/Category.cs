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

    public Category? Parent => _parent;

    public Guid LogoId => _logoId;

    public IReadOnlyCollection<Product> Products => _products.AsReadOnly();

    public IReadOnlyCollection<Category> Children => _children.AsReadOnly();

    public void SetTitle(SetCategoryTitleParameters parameters)
    {
        if (_title == parameters.Title)
        {
            return;
        }
        
        _title = parameters.Title;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void SetParent(SetCategoryParentParameters parameters)
    {
        if (_parent == parameters.Parent)
        {
            return;
        }
        
        _parent = parameters.Parent;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void SetLogoId(SetCategoryLogoIdParameters parameters)
    {
        if (_logoId == parameters.LogoId)
        {
            return;
        }
        
        _logoId = parameters.LogoId;
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
            TimeProvider = parameters.TimeProvider,
            Photo = parameters.Product.Photo,
            Quantity = parameters.Quantity
        }));
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void RemoveProduct(RemoveProductFromCategoryParameters parameters)
    {
        _products.Remove(parameters.Product);
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void RemoveChildren(RemoveCategoryChildrenParameters parameters)
    {
        foreach (var child in parameters.Children)
        {
            _children.Remove(child);
        }
        
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void SetProductTitle(SetCategoryProductTitleParameters parameters)
    {
        var productWithSameTitle = _products.SingleOrDefault(p => p.Title == parameters.Title);
        if (!ReferenceEquals(productWithSameTitle, default))
        {
            return;
        }
        
        var product = _products.SingleOrDefault(p => p.Id == parameters.ProductId);
        if (ReferenceEquals(product, default))
        {
            return;
        }

        if (product.Title == parameters.Title)
        {
            return;
        }
        
        if (parameters.Title == string.Empty)
        {
            return;
        }
        
        product.SetTitle(new SetProductTitleParameters
        {
            Title = parameters.Title,
            TimeProvider = parameters.TimeProvider
        });

        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void SetProductDescriptionTitle(SetCategoryProductDescriptionParameters parameters)
    {
        var product = _products.SingleOrDefault(p => p.Id == parameters.ProductId);
        if (ReferenceEquals(product, default))
        {
            return;
        }

        if (product.Description == parameters.Description)
        {
            return;
        }
        
        if (parameters.Description == string.Empty)
        {
            return;
        }
        
        product.SetDescription(new SetProductDescriptionParameters
        {
            Description = parameters.Description,
            TimeProvider = parameters.TimeProvider
        });

        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void SetProductQuantity(SetCategoryProductQuantityParameters parameters)
    {
        var product = _products.SingleOrDefault(p => p.Id == parameters.ProductId);
        if (ReferenceEquals(product, default))
        {
            return;
        }

        if (product.Quantity == parameters.Quantity)
        {
            return;
        }

        if (product.Quantity < 0)
        {
            return;
        }
        
        product.SetQuantity(new SetProductQuantityParameters
        {
            Quantity = parameters.Quantity,
            TimeProvider = parameters.TimeProvider
        });
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void SetProductPhoto(SetCategoryProductPhotoParameters parameters)
    {
        var product = _products.SingleOrDefault(p => p.Id == parameters.ProductId);
        if (ReferenceEquals(product, default))
        {
            return;
        }
        
        product.UpdatePhoto(new SetProductPhotoParameters
        {
            TimeProvider = parameters.TimeProvider
        });

        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
}