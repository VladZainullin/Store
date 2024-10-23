using Application.Contracts.Features.Categories.Commands.UpdateProductInCategory;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/categories/{categoryId:guid}/products/{productId:guid}")]
public sealed class ProductController : AppController
{
    [HttpPut]
    public async Task<NoContentResult> UpdateProductInCategoryAsync(
        [FromRoute] UpdateProductInCategoryRequestRouteDto routeDto,
        [FromBody] UpdateProductInCategoryRequestBodyDto bodyDto)
    {
        await Sender.Send(new UpdateProductInCategoryCommand(routeDto, bodyDto), HttpContext.RequestAborted);

        return NoContent();
    }
}