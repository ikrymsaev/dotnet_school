using Application.Features.Tags.Commands;
using Application.Features.Tags.Dto;
using Application.Features.Tags.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class TagsController : BaseApiController
{
    /// <summary>
    /// Получить список тэгов.
    /// </summary>
    /// <returns></returns>
    [HttpGet()]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<TagDto>>> GetAllTags() =>
        Ok(await Mediator.Send(new GetAllTagsQuery()));

    /// <summary>
    /// Получить тэг по идентификатору
    /// </summary>
    /// <param name="tagId"></param>
    /// <returns></returns>
    [HttpGet($"{{{nameof(tagId)}:long}}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<TagDto>> GetTagById(long tagId)
    {
        var result = await Mediator.Send(new GetTagByIdQuery(tagId));
        if (result is null) return NotFound();

        return Ok(result);
    }
    
    /// <summary>
    /// Создать тэг
    /// </summary>
    [HttpPost()]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<TagDto>> CreateTag([FromBody] CreateTagDto dto) =>
        CreatedAtAction(nameof(CreateTag), await Mediator.Send(new CreateTagCommand(dto)));

    /// <summary>
    /// Редактировать тэг
    /// </summary>
    [HttpPut($"{{{nameof(tagId)}:long}}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<TagDto>> UpdateTag(long tagId, [FromBody] CreateTagDto dto)
    {
        var result = await Mediator.Send(new UpdateTagCommand(tagId, dto));
        if (result is null)
            return NotFound();
        
        return Ok(result);
    }
    
    /// <summary>
    /// Удалить тэг
    /// </summary>
    [HttpDelete($"{{{nameof(tagId)}:long}}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<long>> DeleteTag(long tagId)
    {
        var result = await Mediator.Send(new DeleteTagCommand(tagId));
        if (result is null)
            return NotFound();
        
        return NoContent();
    }
}