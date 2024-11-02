// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Domain.Entities.ProductInCarts.Parameters;

public readonly struct SetProductInBucketProductParameters
{
    public required Guid ProductId { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}