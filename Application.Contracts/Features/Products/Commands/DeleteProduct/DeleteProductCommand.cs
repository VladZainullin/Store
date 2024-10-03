using MediatR;

namespace Application.Contracts.Features.Products.Commands.DeleteProduct;

public sealed record DeleteProductCommand(DeleteProductRequestRouteDto RequestRouteDto) : IRequest;