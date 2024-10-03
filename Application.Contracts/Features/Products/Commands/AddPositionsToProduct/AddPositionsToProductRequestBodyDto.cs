namespace Application.Contracts.Features.Products.Commands.AddPositionsToProduct;

public sealed class AddPositionsToProductRequestBodyDto
{
    public required IReadOnlyCollection<VodkaPositionDto> Positions { get; init; }
    
    public sealed class VodkaPositionDto
    {
        public required string Title { get; init; }

        public required string Description { get; init; }
    }
}