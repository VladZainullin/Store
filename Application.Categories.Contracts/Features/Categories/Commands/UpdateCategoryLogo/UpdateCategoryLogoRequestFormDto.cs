using Microsoft.AspNetCore.Http;

namespace Application.Categories.Contracts.Features.Categories.Commands.UpdateCategoryLogo;

public class UpdateCategoryLogoRequestFormDto
{
    public required IFormFile Logo { get; init; }
}