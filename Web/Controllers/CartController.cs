using Application.Contracts.Features.Carts.Commands.CleanCart;
using Application.Contracts.Features.Carts.Queries.GetProductsInCart;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/v1/cart")]
public sealed class CartController : AppController
{
    [HttpGet]
    public async Task<ActionResult<GetProductsInCartResponseDto>> GetProductsInCartAsync(
        [FromQuery] GetProductsInCartQueryDto query)
    {
        return Ok(await Sender.Send(new GetProductsInCartQuery(query), HttpContext.RequestAborted));
    }
    
    [HttpDelete]
    public async Task<NoContentResult> CleanCartAsync()
    {
        await Sender.Send(new CleanCartCommand(), HttpContext.RequestAborted);

        return NoContent();
    }
}