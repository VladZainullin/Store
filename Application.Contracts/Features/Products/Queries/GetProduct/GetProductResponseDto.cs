namespace Application.Contracts.Features.Products.Queries.GetProduct;

public sealed record GetProductResponseDto
{
    public required Guid ProductId { get; init; }
    
    public required string Title { get; init; }

    public required string Description { get; init; }

    public required int InCart { get; init; }

    public required int InWarehouse { get; init; }
}