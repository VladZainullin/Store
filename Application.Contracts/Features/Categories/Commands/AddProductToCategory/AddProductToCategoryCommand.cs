using MediatR;

namespace Application.Contracts.Features.Categories.Commands.AddProductToCategory;

public sealed record AddProductToCategoryCommand(AddProductToCategoryRequestRouteDto Route) : 
    IRequest<AddProductToCategoryResponseDto>;