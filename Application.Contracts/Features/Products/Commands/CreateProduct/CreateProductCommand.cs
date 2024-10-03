using MediatR;

namespace Application.Contracts.Features.Products.Commands.CreateProduct;

public sealed record CreateProductCommand(CreateProductBodyDto BodyDto) : IRequest<CreateProductResponseDto>;