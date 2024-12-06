using Mediator;

namespace Application.Contracts.Features.Characteristics.Commands.UpdateCharacteristic;

public sealed record UpdateCharacteristicCommand(
    UpdateCharacteristicRequestRouteDto Route,
    UpdateCharacteristicRequestBodyDto Body) : IRequest;