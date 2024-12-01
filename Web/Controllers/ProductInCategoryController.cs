using Application.Contracts.Features.Categories.Commands.AddProductToCategory;
using Application.Contracts.Features.Categories.Commands.RemoveProductFromCategory;
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
}