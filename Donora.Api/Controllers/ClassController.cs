using Microsoft.AspNetCore.Mvc;
using Donora.Api.Controllers;
using Donora.Shared.Abstractions.Commands;
using Donora.Shared.Abstractions.Queries;

public class ClassController : BaseController
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public ClassController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpPost]
    public async Task<IActionResult> AddClass([FromBody] CreateClassCommand command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok(true);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateClass([FromBody] UpdateClassCommand command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok(true);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteClass([FromBody] DeleteClassCommand command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok(true);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClassEntityDto>>> GetClasses([FromQuery] GetClasses query)
    {
        var result = await _queryDispatcher.QueryAsync(query);

        return Ok(result);
    }

}