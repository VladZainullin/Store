using MediatR;

namespace Application.Contracts.Features.Buckets.Commands.CleanBucket;

public sealed record CleanBucketCommand : IRequest;