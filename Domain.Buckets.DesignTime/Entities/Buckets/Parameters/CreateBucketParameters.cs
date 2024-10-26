namespace Domain.Entities.Buckets.Parameters;

public readonly struct CreateBucketParameters
{
    public required Guid ClientId { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}