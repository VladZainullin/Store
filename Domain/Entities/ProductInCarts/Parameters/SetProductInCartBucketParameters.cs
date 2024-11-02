// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Domain.Entities.ProductInCarts.Parameters;

public readonly struct SetProductInCartBucketParameters
{
    public required Guid BucketId { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}