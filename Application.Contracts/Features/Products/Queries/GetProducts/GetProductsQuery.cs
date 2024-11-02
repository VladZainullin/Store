using MediatR;

namespace Application.Contracts.Features.Products.Queries.GetProducts;

public sealed record GetProductsQuery(GetProductsRequestQueryDto QueryDto) : 
    IRequest<GetProductsResponseDto>;