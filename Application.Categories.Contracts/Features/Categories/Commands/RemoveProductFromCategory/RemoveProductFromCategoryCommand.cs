using MediatR;

namespace Application.Categories.Contracts.Features.Categories.Commands.RemoveProductFromCategory;

public sealed record RemoveProductFromCategoryCommand(RemoveProductFromCategoryRequestRouteDto RouteDto) : IRequest;