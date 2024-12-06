using Mediator;

namespace Application.Contracts.Features.Products.Commands.AddCharacteristicToProduct;

public sealed record AddCharacteristicToProductCommand(
    AddCharacteristicToProductRequestRouteDto Route,
    AddCharacteristicToProductRequestBodyDto Body) : IRequest;