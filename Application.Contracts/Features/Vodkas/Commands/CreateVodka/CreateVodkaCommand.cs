using MediatR;

namespace Application.Contracts.Features.Vodkas.Commands.CreateVodka;

public sealed record CreateVodkaCommand(CreateVodkaBodyDto BodyDto) : IRequest<CreateVodkaResponseDto>;