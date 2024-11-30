using Application.Contracts.Features.Products.Commands.RemoveCharacteristicFromProduct;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/v1/products/{productId:guid}/characteristics/{characteristicId:guid}")]
internal sealed class ProductCharacteristicController : AppController
{
    [HttpDelete]
    public async Task<NoContentResult> RemoveProductCharacteristicAsync(
        RemoveCharacteristicFromProductRouteDto route)
    {
        await Sender.Send(new RemoveCharacteristicFromProductCommand(route), HttpContext.RequestAborted);

        return NoContent();
    }
}