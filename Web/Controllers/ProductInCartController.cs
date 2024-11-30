using Application.Contracts.Features.Carts.Commands.AddProductToCart;
using Application.Contracts.Features.Carts.Commands.RemoveProductFromCart;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/v1/cart/products/{productId:guid}")]
public sealed class ProductInCartController : AppController
{
    [HttpPost]
    public async Task<NoContentResult> AddProductToCartAsync(
        [FromRoute] AddProductToCartRequestRouteDto route,
        [FromBody] AddProductToCartRequestBodyDto body)
    {
        await Sender.Send(new AddProductToCartCommand(route, body), HttpContext.RequestAborted);

        return NoContent();
    }

    [HttpDelete]
    public async Task<NoContentResult> RemoveProductFromCartAsync(
        [FromRoute] RemoveProductFromCartRequestRouteDto route,
        [FromBody] RemoveProductFromCartRequestBodyDto body)
    {
        await Sender.Send(new RemoveProductFromCartCommand(route, body), HttpContext.RequestAborted);
        
        return NoContent();
    }
}