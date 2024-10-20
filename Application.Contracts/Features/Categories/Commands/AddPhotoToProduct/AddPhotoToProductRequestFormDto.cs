using Microsoft.AspNetCore.Http;
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Application.Contracts.Features.Categories.Commands.AddPhotoToProduct;

public sealed class AddPhotoToProductRequestFormDto
{
    public required IFormFile Photo { get; init; }
}