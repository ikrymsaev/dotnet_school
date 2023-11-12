using Application.Features.Courses.Commands;
using Application.Features.Courses.Queries;
using Application.Features.Courses.ViewModel;
using Domain.Courses.Dto;
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
    /// <param name="courseId">ИД курса</param>
    /// <returns>CourseVm</returns>
    [HttpGet("{courseId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CourseVm>> GetById(long courseId)
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
    /// <param name="courseId">ИД курса</param>
    /// <param name="dto">Данные курса</param>
    /// <returns>CourseVm</returns>
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
    /// <param name="courseId">ИД курса</param>
    /// <returns>long courseId</returns>
    [HttpDelete("{courseId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<long>> DeleteCourse(long courseId)
    {
        var result = await Mediator.Send(new DeleteCourseCommand(courseId));
        
        if (result is null) return NotFound();
        return NoContent();
    }

}