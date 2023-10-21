using Application.Features.Lessons.Dto;
using Application.Features.Lessons.Queries;
using Domain.Lessons;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class LessonsController : BaseApiController
{
    [HttpGet("{id:long}")]
    public async Task<ActionResult<LessonDto>> GetById(long id)
    {
        var result = await Mediator.Send(new GetLessonQuery(id));
        return Ok(result);
    }
}