using Mediator;

namespace Application.Contracts.Features.Characteristics.Commands.RemoveCharacteristic;

public sealed record RemoveCharacteristicCommand(
    RemoveCharacteristicRequestRouteDto Route) : IRequest;