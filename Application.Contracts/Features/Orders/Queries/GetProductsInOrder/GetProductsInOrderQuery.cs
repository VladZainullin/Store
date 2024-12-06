using Mediator;

namespace Application.Contracts.Features.Orders.Queries.GetProductsInOrder;

public sealed record GetProductsInOrderQuery(
    GetProductsInOrderRequestRouteDto Route,
    GetProductsInOrderRequestQueryDto Query) : IRequest<GetProductsInOrderResponseDto>;