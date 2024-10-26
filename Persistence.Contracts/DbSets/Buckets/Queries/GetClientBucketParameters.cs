// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Persistence.Contracts.DbSets.Buckets.Queries;

public readonly struct GetClientBucketParameters
{
    public required Guid ClientId { get; init; }

    public required bool AsTracking { get; init; }

    public required bool IncludeProducts { get; init; }
}