using Application.Contracts.Features.Products.Commands.CreateProduct;
using Application.Contracts.Features.Products.Commands.RemoveProduct;
using Application.Contracts.Features.Products.Queries.GetProducts;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/categories/{categoryId:guid}/products")]
public sealed class ProductsController : AppController
{
    [HttpGet]
    public async Task<ActionResult<GetProductsResponseDto>> GetProductsAsync(
        [FromQuery] GetProductsRequestQueryDto query)
    {
        return Ok(await Sender.Send(new GetProductsQuery(query), HttpContext.RequestAborted));
    }
    
    [HttpPost]
    public async Task<NoContentResult> AddProductToCategoryAsync(
        [FromForm] CreateProductRequestBodyDto bodyDto)
    {
        await Sender.Send(new CreateProductCommand(bodyDto), HttpContext.RequestAborted);

        return NoContent();
    }

    [HttpDelete]
    public async Task<NoContentResult> RemoveProductFromCategoryAsync(
        [FromRoute] RemoveProductRequestRouteDto routeDto)
    {
        await Sender.Send(new RemoveProductCommand(routeDto), HttpContext.RequestAborted);

        return NoContent();
    }
}