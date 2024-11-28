using Application.Contracts.Features.Orders.Commands.CancelOrder;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/v1/orders/{orderId:guid}")]
public sealed class OrderController : AppController
{
    [HttpPut("cancel")]
    public async Task<NoContentResult> CancelOrderAsync(
        [FromRoute] CancelOrderRequestRouteDto route)
    {
        await Sender.Send(new CancelOrderCommand(route), HttpContext.RequestAborted);
        return NoContent();
    }
}