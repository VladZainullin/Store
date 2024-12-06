using Mediator;

namespace Application.Contracts.Features.Addresses.Commands.CreateAddress;

public sealed record CreateAddressCommand(
    CreateAddressRequestBodyDto Body) : IRequest<CreateAddressResponseDto>;