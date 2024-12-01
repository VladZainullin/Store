using Application.Contracts.Features.Categories.Commands.AddProductToCategory;
using Application.Contracts.Features.Categories.Queries.GetProductsInCategory;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/v1/categories/{categoryId:guid}/products")]
public sealed class ProductsInCategoryController : AppController
{
    [HttpGet]
    public async Task<ActionResult<GetProductsInCategoryResponseDto>> GetProductsInCategoryAsync(
        [FromRoute] GetProductsInCategoryRequestRouteDto route,
        [FromQuery] GetProductsInCategoryRequestQueryDto query)
    {
        return Ok(await Sender.Send(new GetProductsInCategoryQuery(route, query), HttpContext.RequestAborted));
    }
    
    [HttpPost]
    public async Task<StatusCodeResult> AddProductToCategoryAsync(
        [FromRoute] AddProductToCategoryRequestRouteDto route,
        [FromBody] AddProductToCategoryRequestBodyDto body)
    {
        await Sender.Send(new AddProductToCategoryCommand(route, body), HttpContext.RequestAborted);
        return StatusCode(StatusCodes.Status201Created);
    }
}