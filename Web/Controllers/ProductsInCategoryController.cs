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
}