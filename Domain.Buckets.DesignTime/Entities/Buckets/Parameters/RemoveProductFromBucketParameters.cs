// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Domain.Entities.Buckets.Parameters;

public readonly struct RemoveProductFromBucketParameters
{
    public required Guid ProductId { get; init; }

    public required int Quantity { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}