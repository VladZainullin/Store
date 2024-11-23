// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Domain.Entities.Categories.Parameters;

public readonly struct AddProductToCategoryParameters
{
    public required Guid ProductId { get; init; }
    
    public required TimeProvider TimeProvider { get; init; }
}