using MediatR;

namespace Application.Categories.Contracts.Features.Categories.Commands.UpdateCategoryLogo;

public sealed record UpdateCategoryLogoCommand(
    UpdateCategoryLogoRequestRouteDto RouteDto,
    UpdateCategoryLogoRequestFormDto FormDto) : IRequest;