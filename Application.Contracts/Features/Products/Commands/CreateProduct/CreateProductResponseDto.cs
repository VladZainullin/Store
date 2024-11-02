namespace Application.Contracts.Features.Products.Commands.CreateProduct;

public sealed class CreateProductResponseDto
{
    public required Guid ProductId { get; init; }
}