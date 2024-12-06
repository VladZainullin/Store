using Mediator;

namespace Application.Contracts.Features.Products.Commands.RemoveCharacteristicFromProduct;

public sealed record RemoveCharacteristicFromProductCommand(
    RemoveCharacteristicFromProductRouteDto Route) : IRequest;