namespace Application.Contracts.Features.Products.Commands.AddPositionsToProduct;

public sealed class AddPositionsToProductRequestBodyDto
{
    public required IReadOnlyCollection<ProductPositionDto> Positions { get; init; }
    
    public sealed class ProductPositionDto
    {
        public required string Title { get; init; }

        public required string Description { get; init; }
    }
}