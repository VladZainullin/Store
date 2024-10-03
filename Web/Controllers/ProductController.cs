using Application.Contracts.Features.Products.Commands.DeleteProduct;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/products/{productId:guid}")]
public sealed class ProductController : AppController
{
    [HttpDelete]
    public async Task<NoContentResult> DeleteProductAsync([FromRoute] DeleteProductRequestRouteDto routeDto)
    {
        await Sender.Send(new DeleteProductCommand(routeDto), HttpContext.RequestAborted);

        return NoContent();
    }
}