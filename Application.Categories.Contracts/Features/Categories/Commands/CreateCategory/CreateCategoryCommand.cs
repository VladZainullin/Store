using MediatR;

namespace Application.Categories.Contracts.Features.Categories.Commands.CreateCategory;

public sealed record CreateCategoryCommand(
    CreateCategoryRequestFormDto FormDto) :
    IRequest<CreateCategoryResponseDto>;