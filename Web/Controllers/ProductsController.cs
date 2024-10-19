using Application.Contracts.Features.Categories.Commands.AddProductToCategory;
using Application.Contracts.Features.Categories.Commands.RemoveProductFromCategory;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/categories/{categoryId:guid}/products/{productId:guid}")]
public sealed class ProductsController : AppController
{
    [HttpPost]
    public async Task<NoContentResult> AddProductToCategoryAsync(
        [FromRoute] AddProductToCategoryRequestRouteDto routeDto,
        [FromBody] AddProductToCategoryRequestBodyDto bodyDto)
    {
        await Sender.Send(new AddProductToCategoryCommand(routeDto, bodyDto), HttpContext.RequestAborted);

        return NoContent();
    }

    [HttpDelete]
    public async Task<NoContentResult> RemoveProductFromCategoryAsync(
        [FromRoute] RemoveProductFromCategoryRequestRouteDto routeDto)
    {
        await Sender.Send(new RemoveProductFromCategoryCommand(routeDto), HttpContext.RequestAborted);

        return NoContent();
    }
}