using Store.Domain.Products.ValueObjects;
using Store.Domain.ValueObjects;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Local
namespace Store.Domain.Products;

public sealed class Product
{
    public Product(
        ProductTitle title,
        ProductDescription description,
        ProductCost cost)
    {
        Title = title;
        Description = description;
        Cost = cost;
    }
    
    public Id<Guid> Id { get; private set; } = Guid.NewGuid();
    
    public ProductTitle Title { get; private set; }
    public ProductDescription Description { get; private set; }
    public ProductCost Cost { get; private set; }
}