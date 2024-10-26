using MediatR;

namespace Application.Categories.Contracts.Features.Categories.Commands.UpdateProductInCategory;

public sealed record UpdateProductInCategoryCommand(
    UpdateProductInCategoryRequestRouteDto RouteDto,
    UpdateProductInCategoryRequestBodyDto BodyDto) : IRequest;