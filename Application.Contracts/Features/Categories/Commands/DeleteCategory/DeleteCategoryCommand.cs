using MediatR;

namespace Application.Contracts.Features.Categories.Commands.DeleteCategory;

public sealed record DeleteCategoryCommand(DeleteCategoryRequestRouteDto RouteDto) : IRequest;