namespace Application.Contracts.Features.Vodkas.Commands.UpdateVodka;

public sealed class UpdateVodkaRouteDto
{
    public required Guid VodkaId { get; init; }
}