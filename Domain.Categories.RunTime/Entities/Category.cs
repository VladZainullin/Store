using Domain.Categories.Events;

namespace Domain.Entities;

public sealed class Category
{
    private Category()
    {
    }

    public Category(CategoryCreatedEvent @event) : this()
    {
        Id = @event.CategoryId;
        Title = @event.Title;
    }
    
    public Guid Id { get; private set; }

    public string Title { get; private set; } = default!;

    public void Apply(CategoryTitleSetEvent @event)
    {
        Title = @event.Title;
    }
}