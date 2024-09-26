namespace Application.Contracts.Features.Vodkas.Commands.UpdateVodka;

public sealed class UpdateVodkaBodyDto
{
    public required string Title { get; init; }
    
    public required string Description { get; init; }
}