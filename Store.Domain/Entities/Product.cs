using Store.Domain.ValueObjects;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Local
namespace Store.Domain.Entities;

public sealed class Product
{
#pragma warning disable CS8618
    private Product()
#pragma warning restore CS8618
    {
    }

    public Product(
        ProductTitle title,
        ProductDescription description,
        ProductCost cost) : this()
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