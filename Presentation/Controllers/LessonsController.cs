using Application.Features.Courses.Commands;
using Application.Features.Lessons.Commands;
using Application.Features.Lessons.Commands.Dto;
using Application.Features.Lessons.Queries;
using Application.Features.Lessons.Queries.ViewModels;
using Domain.Lessons.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class LessonsController : BaseApiController
{

    /// <summary>
    /// Получить список занятий
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<LessonVm>>> GetLessons()
    {
        var result = await Mediator.Send(new GetLessonsListQuery());
        return Ok(result);
    }
    
    /// <summary>
    /// Получить занятие по Id
    /// </summary>
    /// <param name="lessonId">Id занятия</param>
    /// <returns>Данные занятия</returns>
    [HttpGet("{lessonId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<LessonInfoVm>> GetById(long lessonId)
    {
        var result = await Mediator.Send(new GetLessonQuery(lessonId));
        
        if (result is null) return NotFound();
        return Ok(result);
    }

    /// <summary>
    /// Создать новое занятие
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<LessonVm>> CreateLesson([FromBody] CreateLessonDto dto)
    {
        var result = await Mediator.Send(new CreateLessonCommand(dto));
        return CreatedAtAction(nameof(CreateLesson), result);
    }

    /// <summary>
    /// Обновить занятие
    /// </summary>
    [HttpPut("{lessonId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<LessonVm>> UpdateLesson(long lessonId, [FromBody] CreateLessonDto dto)
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

    /// <summary>
    /// Прикрепить теги к уроку
    /// </summary>
    [HttpPost("AddTagsTo/{lessonId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<long>>> AddTagsTo(long lessonId, [FromBody] List<long> tagIds)
    {
        var result = await Mediator.Send(new AddTagsToLessonCommand(lessonId, tagIds));
        
        if (result is null) return NotFound();
        return Ok(result);
    }
    
    /// <summary>
    /// Открепить теги от урока
    /// </summary>
    [HttpPost("RemoveTagsFrom/{lessonId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<long>>> RemoveTagsFrom(long lessonId, [FromBody] List<long> tagIds)
    {
        var result = await Mediator.Send(new RemoveTagsFromLessonCommand(lessonId, tagIds));
        
        if (result is null) return NotFound();
        return Ok(result);
    }
    
    /// <summary>
    /// Изменить статус урока
    /// </summary>
    [HttpPut("ChangeStatus/{lessonId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ELessonStatus>> ChangeLessonStatus(long lessonId, [FromBody] ChangeLessonStatusDto dto)
    {
        var result = await Mediator.Send(new ChangeLessonStatusCommand(lessonId, dto));
        
        if (result is null) return NotFound();
        return Ok(result);
    }
}