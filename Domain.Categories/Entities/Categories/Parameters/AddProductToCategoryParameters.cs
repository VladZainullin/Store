// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Domain.Categories.Entities.Categories.Parameters;

public sealed class AddProductToCategoryParameters
{
    public required ProductParameter Product { get; init; }

    public required TimeProvider TimeProvider { get; init; }
    
    public readonly struct ProductParameter
    {
        public required string Title { get; init; }

        public required string Description { get; init; }

        public Guid Photo => Guid.NewGuid();
    }
}