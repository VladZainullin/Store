namespace Application.Contracts.Features.Vodkas.Commands.DeleteVodkas;

public sealed class DeleteVodkasBodyDto
{
    public required IReadOnlyCollection<Guid> VodkaIds { get; init; }
}