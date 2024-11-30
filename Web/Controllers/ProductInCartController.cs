using Application.Contracts.Features.Carts.Commands.DecrementProductFromCart;
using Application.Contracts.Features.Carts.Commands.IncrementProductToCart;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/v1/cart/products/{productId:guid}")]
public sealed class ProductInCartController : AppController
{
    [HttpPut("increment")]
    public async Task<NoContentResult> IncrementProductToCartAsync(
        [FromRoute] IncrementProductToCartRequestRouteDto route,
        [FromBody] IncrementProductToCartRequestBodyDto body)
    {
        await Sender.Send(new IncrementProductToCartCommand(route, body), HttpContext.RequestAborted);

        return NoContent();
    }

    [HttpPut("decrement")]
    public async Task<NoContentResult> DecrementProductFromCartAsync(
        [FromRoute] DecrementProductFromCartRequestRouteDto route,
        [FromBody] DecrementProductFromCartRequestBodyDto body)
    {
        await Sender.Send(new DecrementProductFromCartCommand(route, body), HttpContext.RequestAborted);
        
        return NoContent();
    }
}