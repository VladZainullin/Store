using MediatR;

namespace Application.Contracts.Features.Carts.Queries.GetProductsInCart;

public sealed record GetProductsInCartQuery(GetProductsInCartQueryDto Query) : 
    IRequest<GetProductsInCartResponseDto>;