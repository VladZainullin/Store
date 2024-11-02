using MediatR;

namespace Application.Contracts.Features.Products.Commands.UpdateProductPhoto;

public sealed record UpdateProductPhotoCommand(
    UpdateProductPhotoRequestRouteDto RouteDto,
    UpdateProductPhotoRequestFormDto FormDto) : IRequest;