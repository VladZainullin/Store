using MediatR;

namespace Application.Contracts.Features.Products.Commands.DeleteProducts;

public sealed record DeleteProductsCommand(DeleteProductsBodyDto BodyDto) : IRequest;