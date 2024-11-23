using Application.Contracts.Features.Products.Commands.CreateProduct;
using Application.Contracts.Features.Products.Commands.RemoveProduct;
using Application.Contracts.Features.Products.Queries.GetProducts;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/products")]
public sealed class ProductsController : AppController
{
    [HttpGet]
    public async Task<ActionResult<GetProductsResponseDto>> GetProductsAsync(
        [FromQuery] GetProductsRequestQueryDto query)
    {
        return Ok(await Sender.Send(new GetProductsQuery(query), HttpContext.RequestAborted));
    }
    
    [HttpPost]
    public async Task<ActionResult<CreateProductResponseDto>> CreateProductAsync(
        [FromBody] CreateProductRequestBodyDto bodyDto)
    {
        var response = await Sender.Send(new CreateProductCommand(bodyDto), HttpContext.RequestAborted);
        return StatusCode(StatusCodes.Status201Created, response);
    }

    [HttpDelete]
    public async Task<NoContentResult> RemoveProductAsync(
        [FromRoute] RemoveProductRequestRouteDto routeDto)
    {
        await Sender.Send(new RemoveProductCommand(routeDto), HttpContext.RequestAborted);

        return NoContent();
    }
}