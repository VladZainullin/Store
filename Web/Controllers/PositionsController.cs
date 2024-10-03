using Application.Contracts.Features.Products.Commands.AddPositionsToProduct;
using Application.Contracts.Features.Products.Commands.DeletePositionsFromProduct;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/products/{productId:guid}/positions")]
public sealed class PositionsController : AppController
{
    [HttpPost]
    public async Task<NoContentResult> AddPositionsToProductAsync(
        [FromRoute] AddPositionsToProductRequestRouteDto routeDto,
        [FromBody] AddPositionsToProductRequestBodyDto bodyDto)
    {
        await Sender.Send(new AddPositionsToProductCommand(routeDto, bodyDto), HttpContext.RequestAborted);

        return NoContent();
    }
    
    [HttpDelete]
    public async Task<NoContentResult> DeletePositionsToProductAsync(
        [FromRoute] DeletePositionsFromProductRequestRouteDto routeDto,
        [FromBody] DeletePositionsFromProductRequestBodyDto bodyDto)
    {
        await Sender.Send(new DeletePositionsFromProductCommand(routeDto, bodyDto), HttpContext.RequestAborted);

        return NoContent();
    }
}