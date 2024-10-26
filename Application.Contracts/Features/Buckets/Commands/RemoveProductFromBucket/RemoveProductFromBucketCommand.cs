using MediatR;

namespace Application.Contracts.Features.Buckets.Commands.RemoveProductFromBucket;

public sealed record RemoveProductFromBucketCommand(
    RemoveProductFromBucketRequestRouteDto RouteDto,
    RemoveProductFromBucketRequestBodyDto BodyDto) : IRequest;