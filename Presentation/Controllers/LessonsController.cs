using Application.Features.Lessons.Commands;
using Application.Features.Lessons.Dto;
using Application.Features.Lessons.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class LessonsController : BaseApiController
{

    /// <summary>
    /// Получить список занятий
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<LessonDto>>> GetLessons()
    {
        var result = await Mediator.Send(new GetLessonsListQuery());
        return Ok(result);
    }
    
    /// <summary>
    /// Получить занятие id
    /// </summary>
    [HttpGet($"{{{nameof(id)}:long}}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<LessonDto>> GetById(long id)
    {
        var result = await Mediator.Send(new GetLessonQuery(id));
        
        if (result is null) return NotFound();
        return Ok(result);
    }

    /// <summary>
    /// Создать новое занятие
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<LessonDto>> CreateLesson([FromBody] CreateLessonDto dto)
    {
        var result = await Mediator.Send(new CreateLessonCommand(dto));
        return CreatedAtAction(nameof(CreateLesson), result);
    }

    /// <summary>
    /// Обновить занятие
    /// </summary>
    [HttpPut("{lessonId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<LessonDto>> UpdateLesson(long lessonId, [FromBody] CreateLessonDto dto)
    {
        var result = await Mediator.Send(new UpdateLessonCommand(lessonId, dto));
        
        if (result is null) return NotFound();
        return Ok(result);
    }
    
    /// <summary>
    /// Удалить занятие
    /// </summary>
    [HttpDelete("{lessonId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<long>> DeleteLesson(long lessonId)
    {
        var result = await Mediator.Send(new DeleteLessonCommand(lessonId));
        
        if (result is null) return NotFound();
        return NoContent();
    }
}