using Mediator;

namespace Application.Contracts.Features.Categories.Commands.AddProductToCategory;

public sealed record AddProductToCategoryCommand(
    AddProductToCategoryRequestRouteDto Route,
    AddProductToCategoryRequestBodyDto Body) : 
    IRequest;