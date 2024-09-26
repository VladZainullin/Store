namespace Application.Contracts.Features.Vodkas.Commands.DeleteVodka;

public sealed class DeleteVodkaRouteDto
{
    public required Guid VodkaId { get; init; }
}