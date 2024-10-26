namespace Domain.Entities.Buckets.Parameters;

public readonly struct SetBucketClientParameters
{
    public required Guid ClientId { get; init; }

    public required TimeProvider TimeProvider { get; init; }
}