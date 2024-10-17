// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Domain.Categories.Entities.Categories.Parameters;

public readonly struct AddCategoryChildrenParameters
{
    public required IEnumerable<Child> Children { get; init; }

    public required TimeProvider TimeProvider { get; init; }
    
    public readonly struct Child
    {
        public string Title { get; init; }
    }
}