using Microsoft.AspNetCore.Mvc;
using Donora.Api.Controllers;
using Donora.Shared.Abstractions.Commands;
using Donora.Shared.Abstractions.Queries;

public class SectionController : BaseController
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public SectionController(
        ICommandDispatcher commandDispatcher,
        IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpPost]
    public async Task<IActionResult> AddSection([FromBody] CreateSectionCommand command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok(true);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSection([FromBody] UpdateSectionCommand command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok(true);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteSection([FromBody] DeleteSectionCommand command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok(true);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SectionEntityDto>>> GetSections([FromQuery] GetSections query)
    {
        var result = await _queryDispatcher.QueryAsync(query);
        return Ok(result);
    }
}