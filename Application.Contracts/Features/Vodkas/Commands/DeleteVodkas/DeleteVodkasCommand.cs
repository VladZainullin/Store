using MediatR;

namespace Application.Contracts.Features.Vodkas.Commands.DeleteVodkas;

public sealed record DeleteVodkasCommand(DeleteVodkasBodyDto BodyDto) : IRequest;