using Mediator;

namespace Application.Contracts.Features.Orders.Queries.GetOrders;

public sealed record GetOrdersQuery(GetOrdersRequestQueryDto Query) : 
    IRequest<GetOrdersResponseDto>;