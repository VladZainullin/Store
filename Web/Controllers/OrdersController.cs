using Application.Contracts.Features.Orders.Commands.CreateOrder;
using Application.Contracts.Features.Orders.Queries.GetOrders;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/v1/orders")]
public sealed class OrdersController : AppController
{
    [HttpGet]
    public async Task<ActionResult<GetOrdersResponseDto>> GetOrdersAsync(
        [FromQuery] GetOrdersRequestQueryDto query)
    {
        return await Sender.Send(new GetOrdersQuery(query), HttpContext.RequestAborted);
    }

    [HttpPost]
    public async Task<ActionResult<CreateOrderResponseDto>> CreateOrderAsync()
    {
        return await Sender.Send(new CreateOrderCommand(), HttpContext.RequestAborted);
    }
}