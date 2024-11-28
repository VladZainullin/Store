using MediatR;

namespace Application.Contracts.Features.Products.Commands.CreateProduct;

public sealed record CreateProductCommand(CreateProductRequestBodyDto BodyDto) : IRequest<CreateProductResponseDto>;