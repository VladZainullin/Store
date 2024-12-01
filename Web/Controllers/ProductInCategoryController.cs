using Application.Contracts.Features.Categories.Commands.RemoveProductFromCategory;
using Application.Contracts.Features.Categories.Commands.RestoreProductFromCategory;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/v1/categories/{categoryId:guid}/products/{productId:guid}")]
public sealed class ProductInCategoryController : AppController
{
    [HttpDelete]
    public async Task<NoContentResult> RemoveProductFromCategoryAsync(
        [FromRoute] RemoveProductFromCategoryRequestRouteDto route)
    {
        await Sender.Send(new RemoveProductFromCategoryCommand(route), HttpContext.RequestAborted);
        return NoContent();
    }

    [HttpPut("restore")]
    public async Task<NoContentResult> RestoreProductInCategoryAsync(
        [FromRoute] RestoreProductFromCategoryRequestRouteDto route)
    {
        await Sender.Send(new RestoreProductFromCategoryCommand(route), HttpContext.RequestAborted);
        
        return NoContent();
    }
}