using Application.Contracts.Features.Orders.Queries.GetProductsInOrder;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/v1/orders/{orderId:guid}/products")]
public sealed class ProductsInOrderController : AppController
{
    [HttpGet]
    public async Task<ActionResult<GetProductsInOrderResponseDto>> GetProductsInOrderAsync(
        [FromRoute] GetProductsInOrderRequestRouteDto route,
        [FromQuery] GetProductsInOrderRequestQueryDto query)
    {
        return await Sender.Send(new GetProductsInOrderQuery(route, query), HttpContext.RequestAborted);
    }
}