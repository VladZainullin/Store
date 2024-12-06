using Mediator;

namespace Application.Contracts.Features.Products.Commands.RestoreProduct;

public sealed record RestoreProductCommand(RestoreProductRequestRouteDto Route) : 
    IRequest;