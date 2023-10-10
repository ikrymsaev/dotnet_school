using Application.Features.Lessons.Queries;
using Domain.Lessons;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class LessonsController : BaseApiController
{
    [HttpGet("{long:int}")]
    public async Task<ActionResult<Lesson>> GetById(long id)
    {
        var result = await Mediator.Send(new GetLessonQuery(id));
        return Ok(result);
    }
}