using Domain.Categories.Entities.Products.Parameters;

namespace Domain.Categories.Entities.Products;

public sealed class Product
{
    private Guid _id = Guid.NewGuid();
    
    private string _title = default!;
    private string _description = default!;
    
    private Guid _photo = Guid.NewGuid();
    
    private DateTimeOffset _updatedAt;
    private DateTimeOffset _createdAt;

    private int _quantity;

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

    public int Quantity => _quantity;

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

    internal void SetQuantity(SetProductQuantityParameters parameters)
    {
        _quantity = parameters.Quantity;
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }

    public void UpdatePhoto(SetProductPhotoParameters parameters)
    {
        _updatedAt = parameters.TimeProvider.GetUtcNow();
    }
}