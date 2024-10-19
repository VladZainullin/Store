using Domain.Categories.Entities.Products.Parameters;

namespace Domain.Categories.Entities.Products;

public sealed class Product
{
    private Guid _id = Guid.NewGuid();
    
    private string _title = default!;
    private string _description = default!;
    
    private DateTimeOffset _updatedAt;
    private DateTimeOffset _createdAt;

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

        _createdAt = parameters.TimeProvider.GetUtcNow();
    }

    public Guid Id => _id;

    public string Title => _title;
    
    public string Description => _description;
    
    public DateTimeOffset CreatedAt => _createdAt;
    
    public DateTimeOffset UpdatedAt => _updatedAt;

    internal void SetTitle(SetProductTitleParameters parameters)
    {
        _title = parameters.Title.Trim();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    internal void SetDescription(SetProductDescriptionParameters parameters)
    {
        _description = parameters.Description.Trim();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
}