using Domain.Categories.Events;

namespace Domain.Entities;

public sealed class Product
{
    private Product()
    {
    }

    public Product(ProductCreatedEvent @event) : this()
    {
        ProductId = @event.ProductId;
        Title = @event.Title;
        Description = @event.Description;
        Cost = @event.Cost;
        Quantity = @event.Quantity;
        CategoryId = @event.CetegoryId;
        CategoryTitle = @event.CategoryTitle;
    }

    public Guid ProductId { get; private set; }

    public string Title { get; private set; } = default!;

    public string Description { get; private set; } = default!;

    public decimal Cost { get; private set; }

    public int Quantity { get; private set; }

    public Guid CategoryId { get; private set; }

    public string CategoryTitle { get; private set; } = default!;

    public void Apply(ProductTitleSetEvent @event)
    {
        Title = @event.Title;
    }
    
    public void Apply(ProductDescriptionSetEvent @event)
    {
        Title = @event.Description;
    }
    
    public void Apply(ProductCostSetEvent @event)
    {
        Cost = @event.Cost;
    }
    
    public void Apply(ProductQuantitySetEvent @event)
    {
        Quantity = @event.Quantity;
    }
}