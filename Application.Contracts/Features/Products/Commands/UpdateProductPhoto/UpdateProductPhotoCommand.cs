using MediatR;

namespace Application.Contracts.Features.Commands.UpdateProductPhoto;

public sealed record UpdateProductPhotoCommand(
    UpdateProductPhotoRequestRouteDto RouteDto,
    UpdateProductPhotoRequestFormDto FormDto) : IRequest;