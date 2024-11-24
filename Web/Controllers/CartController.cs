using Application.Contracts.Features.Carts.Commands.CleanCart;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/v1/cart")]
public sealed class CartController : AppController
{
    [HttpDelete]
    public async Task<NoContentResult> CleanCartAsync()
    {
        await Sender.Send(new CleanCartCommand());

        return NoContent();
    }
}