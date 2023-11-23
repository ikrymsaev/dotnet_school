using Application.Features.Courses.Commands;
using Application.Features.Courses.Commands.Dto;
using Application.Features.Courses.Queries;
using Application.Features.Courses.Queries.ViewModels;
using Domain.Courses.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class CoursesController : BaseApiController
{
    /// <summary>
    /// Получить список курсов
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<CourseVm>>> GetCourses()
    {
        var result = await Mediator.Send(new GetCoursesListQuery());
        return Ok(result);
    }
    
    /// <summary>
    /// Получить курс
    /// </summary>
    [HttpGet("{courseId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CourseInfoVm>> GetById(long courseId)
    {
        var result = await Mediator.Send(new GetCourseQuery(courseId));
        
        if (result is null) return NotFound();
        return Ok(result);
    }

    /// <summary>
    /// Создать новый курс
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<CourseVm>> CreateCourse([FromBody] CreateCourseDto dto)
    {
        var result = await Mediator.Send(new CreateCourseCommand(dto));
        return CreatedAtAction(nameof(CreateCourse), result);
    }
    
    /// <summary>
    /// Обновить данные курса
    /// </summary>
    [HttpPut("{courseId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CourseVm>> UpdateCourse(long courseId, [FromBody] CreateCourseDto dto)
    {
        var result = await Mediator.Send(new UpdateCourseCommand(courseId, dto));
        
        if (result is null) return NotFound();
        return Ok(result);
    }
    
    /// <summary>
    /// Удалить курс
    /// </summary>
    [HttpDelete("{courseId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<long>> DeleteCourse(long courseId)
    {
        var result = await Mediator.Send(new DeleteCourseCommand(courseId));
        
        if (result is null) return NotFound();
        return NoContent();
    }

    /// <summary>
    /// Включить уроки в курс
    /// </summary>
    [HttpPost("IncludeLessonsTo/{courseId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<long>>> IncludeLessons(long courseId, [FromBody] List<long> lessonIds)
    {
        var result = await Mediator.Send(new IncludeLessonsToCourse(courseId, lessonIds));
        
        if (result is null) return NotFound();
        return Ok(result);
    }
    
    /// <summary>
    /// Исключить уроки из курса
    /// </summary>
    [HttpPost("ExcludeLessonsFrom/{courseId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<long>>> ExcludeLessons(long courseId, [FromBody] List<long> lessonIds)
    {
        var result = await Mediator.Send(new ExcludeLessonsFromCourse(courseId, lessonIds));
        
        if (result is null) return NotFound();
        return Ok(result);
    }
    
    /// <summary>
    /// Сменить статус курса.
    /// </summary>
    [HttpPut("ChangeStatus/{courseId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ECourseStatus>> ChangeCourseStatus(long courseId, [FromBody] ChangeCourseStatusDto dto)
    {
        var result = await Mediator.Send(new ChangeCourseStatusCommand(courseId, dto));
        
        if (result is null) return NotFound();
        return Ok(result);
    }
}