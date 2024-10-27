using MediatR;

namespace Application.Buckets.Contracts.Features.Buckets.Commands.RemoveProductFromBucket;

public sealed record RemoveProductFromBucketCommand(
    RemoveProductFromBucketRequestRouteDto RouteDto,
    RemoveProductFromBucketRequestBodyDto BodyDto) : IRequest;