using MediatR;

namespace Application.Contracts.Features.Addresses.Commands.RemoveAddress;

public sealed record RemoveAddressCommand(RemoveAddressRequestRouteDto Route)
    : IRequest;