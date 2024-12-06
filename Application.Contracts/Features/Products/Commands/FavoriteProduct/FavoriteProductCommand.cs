using Mediator;

namespace Application.Contracts.Features.Products.Commands.FavoriteProduct;

public sealed record FavoriteProductCommand(FavoriteProductRequestRouteDto Route) : IRequest;