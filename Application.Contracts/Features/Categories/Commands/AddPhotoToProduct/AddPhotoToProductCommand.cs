using MediatR;

namespace Application.Contracts.Features.Categories.Commands.AddPhotoToProduct;

public sealed record AddPhotoToProductCommand(
    AddPhotoToProductRequestRouteDto RequestRouteDto,
    AddPhotoToProductRequestFormDto RequestFormDto) : IRequest<AddPhotoToProductResponseDto>;