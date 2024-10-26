using MediatR;

namespace Application.Categories.Contracts.Features.Categories.Commands.AddProductToCategory;

public sealed record AddProductToCategoryCommand(
    AddProductToCategoryRequestRouteDto RouteDto,
    AddProductToCategoryRequestFormDto FormDto) : IRequest<AddProductToCategoryResponseDto>;