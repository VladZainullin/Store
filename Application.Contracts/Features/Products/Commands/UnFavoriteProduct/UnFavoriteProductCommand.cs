using MediatR;

namespace Application.Contracts.Features.Products.Commands.UnFavoriteProduct;

public sealed record UnFavoriteProductCommand(UnFavoriteProductRequestRouteDto Route) : IRequest;