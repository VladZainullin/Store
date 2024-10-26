using MediatR;

namespace Application.Contracts.Features.Buckets.Commands.AddProductToBucket;

public sealed record AddProductToBucketCommand(
    AddProductToBucketRequestRouteDto RouteDto,
    AddProductToBucketRequestBodyDto BodyDto) : IRequest;