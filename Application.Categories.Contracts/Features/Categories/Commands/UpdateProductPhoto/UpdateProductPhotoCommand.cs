using MediatR;

namespace Application.Categories.Contracts.Features.Categories.Commands.UpdateProductPhoto;

public sealed record UpdateProductPhotoCommand(
    UpdateProductPhotoRequestRouteDto RouteDto,
    UpdateProductPhotoRequestFormDto FormDto) : IRequest;