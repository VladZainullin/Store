// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Domain.Entities.Buckets.Parameters;

public readonly struct AddProductToBucketParameters
{
    public required Guid ProductId { get; init; }

    public required int Quantity { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}