// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Domain.Categories.Entities.Categories.Parameters;

public readonly struct RemoveCategoryChildrenParameters
{
    public IEnumerable<Category> Children { get; init; }

    public TimeProvider TimeProvider { get; init; }
}