using Domain.Entities.ProductPositions;
using Domain.Entities.Products.Parameters;

namespace Domain.Entities.Products;

public sealed class Product
{
    private Guid _id = Guid.NewGuid();
    
    private string _title = default!;
    private string _description = default!;

    private readonly List<ProductPosition> _positions = [];
    
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

    public void SetTitle(SetProductTitleParameters parameters)
    {
        _title = parameters.Title.Trim();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
    
    public string Description => _description;

    public void SetDescription(SetProductDescriptionParameters parameters)
    {
        _description = parameters.Description.Trim();
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public IReadOnlyCollection<ProductPosition> Positions => _positions.AsReadOnly();
    
    public DateTimeOffset CreatedAt => _createdAt;
    
    public DateTimeOffset UpdatedAt => _updatedAt;
}