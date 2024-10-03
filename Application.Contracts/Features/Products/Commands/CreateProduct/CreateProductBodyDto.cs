namespace Application.Contracts.Features.Products.Commands.CreateProduct;

public sealed class CreateProductBodyDto
{
    public required string Title { get; init; }
    
    public required string Description { get; init; }
}