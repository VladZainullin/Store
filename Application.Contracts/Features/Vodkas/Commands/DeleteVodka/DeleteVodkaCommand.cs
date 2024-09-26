using MediatR;

namespace Application.Contracts.Features.Vodkas.Commands.DeleteVodka;

public sealed record DeleteVodkaCommand(DeleteVodkaRouteDto RouteDto) : IRequest;