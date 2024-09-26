namespace Application.Contracts.Features.Vodkas.Commands.CreateVodka;

public sealed class CreateVodkaBodyDto
{
    public required string Title { get; init; }
    
    public required string Description { get; init; }
}