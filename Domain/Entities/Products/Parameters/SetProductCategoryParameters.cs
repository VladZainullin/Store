// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Domain.Entities.Products.Parameters;

public sealed class SetProductCategoryParameters
{
    public required Guid CategoryId { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}