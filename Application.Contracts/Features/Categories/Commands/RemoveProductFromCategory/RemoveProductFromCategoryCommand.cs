using Mediator;

namespace Application.Contracts.Features.Categories.Commands.RemoveProductFromCategory;

public sealed record RemoveProductFromCategoryCommand(RemoveProductFromCategoryRequestRouteDto Route) : 
    IRequest;