using MediatR;

namespace Application.Contracts.Features.Commands.CreateProduct;

public sealed record CreateProductCommand(CreateProductRequestFormDto FormDto) : IRequest<CreateProductResponseDto>;