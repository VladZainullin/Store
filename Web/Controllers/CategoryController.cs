using Application.Contracts.Features.Categories.Commands.RemoveCategory;
using Application.Contracts.Features.Categories.Commands.UpdateCategory;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/categories/{categoryId:guid}")]
public sealed class CategoryController : AppController
{
    [HttpDelete]
    public async Task<NoContentResult> RemoveCategoryAsync(
        [FromRoute] RemoveCategoryRequestRouteDto routeDto)
    {
        await Sender.Send(new RemoveCategoryCommand(routeDto), HttpContext.RequestAborted);

        return NoContent();
    }

    [HttpPut]
    public async Task<NoContentResult> UpdateCategoryAsync(
        [FromRoute] UpdateCategoryRequestRouteDto routeDto,
        [FromBody] UpdateCategoryRequestBodyDto bodyDto)
    {
        await Sender.Send(new UpdateCategoryCommand(routeDto, bodyDto), HttpContext.RequestAborted);

        return NoContent();
    }
}