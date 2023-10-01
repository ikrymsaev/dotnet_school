using Application.Features.Lessons.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class LessonsController : BaseApiController
{
    [HttpGet("id:guid")]
    public Task<LessonVm> GetById(Guid id)
    {
        return Mediator.Send(new GetLessonQuery(id));
    }
}