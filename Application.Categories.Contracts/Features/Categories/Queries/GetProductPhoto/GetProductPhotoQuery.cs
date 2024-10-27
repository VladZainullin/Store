using MediatR;

namespace Application.Categories.Contracts.Features.Categories.Queries.GetProductPhoto;

public sealed record GetProductPhotoQuery(GetProductPhotoRequestRouteDto RouteDto) : IRequest<GetProductPhotoResponseDto>;