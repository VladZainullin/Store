// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Domain.Entities.Products.Parameters;

public sealed class UnFavoriteProductParameters
{
    public required Guid ClientId { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}