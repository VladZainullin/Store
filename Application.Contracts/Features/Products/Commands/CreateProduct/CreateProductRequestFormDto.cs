using Microsoft.AspNetCore.Http;

namespace Application.Contracts.Features.Commands.CreateProduct;

public sealed class CreateProductRequestFormDto
{
    public required string Title { get; init; }

    public required string Description { get; init; }
    
    public required int Quantity { get; init; }

    public required decimal Cost { get; init; }

    public required IFormFile Photo { get; init; }
}