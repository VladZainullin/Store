using MediatR;

namespace Application.Buckets.Contracts.Features.Buckets.Commands.CleanBucket;

public sealed record CleanBucketCommand : IRequest;