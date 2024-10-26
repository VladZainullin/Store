namespace Domain.Entities.Buckets.Parameters;

public readonly struct CleanBucketParameters
{
    public required TimeProvider TimeProvider { get; init; }
}