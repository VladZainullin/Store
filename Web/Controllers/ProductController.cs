using Application.Contracts.Features.Products.Commands.UpdateProduct;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/products/{productId:guid}")]
public sealed class ProductController : AppController
{
    [HttpPut]
    public async Task<NoContentResult> UpdateProductInCategoryAsync(
        [FromRoute] UpdateProductRequestRouteDto routeDto,
        [FromBody] UpdateProductRequestBodyDto bodyDto)
    {
        await Sender.Send(new UpdateProductCommand(routeDto, bodyDto), HttpContext.RequestAborted);

        return NoContent();
    }
}