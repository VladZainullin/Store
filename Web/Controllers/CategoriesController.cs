using Application.Contracts.Features.Categories.Commands.CreateCategory;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/categories")]
public sealed class CategoriesController : AppController
{
    [HttpPost]
    public async Task<ActionResult<CreateCategoryResponseDto>> CreateCategoryAsync(
        [FromBody] CreateCategoryRequestBodyDto bodyDto)
    {
        return Ok(await Sender.Send(
            new CreateCategoryCommand(bodyDto), HttpContext.RequestAborted));
    }
}