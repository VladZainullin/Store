using Mediator;

namespace Application.Contracts.Features.Categories.Commands.RestoreProductFromCategory;

public sealed record RestoreProductFromCategoryCommand(
    RestoreProductFromCategoryRequestRouteDto Route) : IRequest;