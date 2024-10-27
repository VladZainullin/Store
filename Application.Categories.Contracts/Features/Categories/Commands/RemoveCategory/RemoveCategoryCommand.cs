using MediatR;

namespace Application.Categories.Contracts.Features.Categories.Commands.RemoveCategory;

public sealed record RemoveCategoryCommand(RemoveCategoryRequestRouteDto RouteDto) : IRequest;