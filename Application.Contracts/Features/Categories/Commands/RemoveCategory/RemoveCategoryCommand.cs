using Mediator;

namespace Application.Contracts.Features.Categories.Commands.RemoveCategory;

public sealed record RemoveCategoryCommand(RemoveCategoryRequestRouteDto Route) : IRequest;