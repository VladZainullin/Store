namespace Application.Contracts.Features.Commands.CreateProduct;

public sealed class CreateProductResponseDto
{
    public required Guid ProductId { get; init; }
}