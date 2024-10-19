using Application.Contracts.Features.Categories.Commands.UpdateProduct;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/categories/{categoryId:guid}/products")]
public sealed class ProductController : AppController
{
    [HttpPut]
    public async Task<NoContentResult> UpdateProductAsync(
        [FromRoute] UpdateProductRequestRouteDto routeDto,
        [FromBody] UpdateProductRequestBodyDto bodyDto)
    {
        await Sender.Send(new UpdateProductCommand(routeDto, bodyDto), HttpContext.RequestAborted);

        return NoContent();
    }
}