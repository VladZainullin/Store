using Application.Contracts.Features.Categories.Commands.AddProductToCategory;
using Application.Contracts.Features.Categories.Commands.RemoveProductFromCategory;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/v1/categories/{categoryId:guid}/products/{productId:guid}")]
public sealed class ProductInCategoryController : AppController
{
    [HttpPost]
    public async Task<ActionResult<AddProductToCategoryResponseDto>> AddProductToCategoryAsync(
        [FromRoute] AddProductToCategoryRequestRouteDto route)
    {
        var response = await Sender.Send(new AddProductToCategoryCommand(route), HttpContext.RequestAborted);
        return StatusCode(StatusCodes.Status201Created, response);
    }

    [HttpDelete]
    public async Task<NoContentResult> RemoveProductFromCategoryAsync(
        [FromRoute] RemoveProductFromCategoryRequestRouteDto route)
    {
        await Sender.Send(new RemoveProductFromCategoryCommand(route), HttpContext.RequestAborted);
        return NoContent();
    }
}