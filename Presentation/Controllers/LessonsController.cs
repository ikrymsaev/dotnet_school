using Application.Features.Lessons.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class LessonsController : BaseApiController
{
    [HttpGet("id:guid")]
    public async Task<ActionResult<LessonVm>> GetById(int id)
    {
        var result = await Mediator.Send(new GetLessonQuery(id));
        return Ok(result);
    }
}