using MediatR;

namespace Application.Contracts.Features.Characteristics.Commands.CreateCharacteristic;

public sealed record CreateCharacteristicCommand(CreateCharacteristicRequestBodyDto Body) : 
    IRequest<CreateCharacteristicResponseDto>;