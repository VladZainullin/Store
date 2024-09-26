using MediatR;

namespace Application.Contracts.Features.Vodkas.Commands.UpdateVodka;

public sealed record UpdateVodkaCommand(UpdateVodkaRouteDto RouteDto, UpdateVodkaBodyDto BodyDto) : IRequest;