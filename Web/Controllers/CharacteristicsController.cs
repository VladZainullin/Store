using Application.Contracts.Features.Characteristics.Commands.CreateCharacteristic;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[Route("api/v1/characteristics")]
public sealed class CharacteristicsController : AppController
{
    [HttpPost]
    public async Task<ActionResult<CreateCharacteristicResponseDto>> CreateCharacteristicAsync(
        [FromBody] CreateCharacteristicRequestBodyDto body)
    {
        return Ok(await Sender.Send(new CreateCharacteristicCommand(body), HttpContext.RequestAborted));
    }
}