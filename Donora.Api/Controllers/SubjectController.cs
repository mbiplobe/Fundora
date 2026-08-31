
using Microsoft.AspNetCore.Mvc;
using Donora.Api.Controllers;
using Donora.Shared.Abstractions.Commands;
using Donora.Shared.Abstractions.Queries;

public class SubjectController : BaseController
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public SubjectController(
        ICommandDispatcher commandDispatcher,
        IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpPost]
    public async Task<IActionResult> AddSubject([FromBody] CreateSubjectCommand command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok(true);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSubject([FromBody] UpdateSubjectCommand command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok(true);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteSubject([FromBody] DeleteSubjectCommand command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok(true);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SubjectEntityDto>>> GetSubjects(
        [FromQuery] GetAllSubjects query)
    {
        var result = await _queryDispatcher.QueryAsync(query);
        return Ok(result);
    }
}