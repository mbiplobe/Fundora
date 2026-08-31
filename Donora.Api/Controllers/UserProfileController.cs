
using Donora.Shared.Abstractions.Commands;
using Donora.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Donora.Api.Controllers;

public class UserProfileController : BaseController
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public UserProfileController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

  [HttpGet("{id}")]
public async Task<ActionResult<UserEntityDto>> GetById([FromRoute] GetUserEntity query)
{
    // var query = new GetUserEntity { Id = id };

    var result = await _queryDispatcher.QueryAsync(query);

    return OkOrNotFound(result);
}

   

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserEntityDto>>> Get([FromQuery] SearchUserEntity query)
    {
        var result = await _queryDispatcher.QueryAsync(query);
        return OkOrNotFound(result);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Post([FromBody] CreateUserCommand command)
    {
        var id = command.Id ?? Guid.NewGuid();
        command = command with { Id = id };
        await _commandDispatcher.DispatchAsync(command);
        return OkOrNotFound(id);
    }

    // [HttpPut("{SampleEntityId}/items")]
    // public async Task<IActionResult> Put([FromBody] AddSampleEntityItem command)
    // {
    //     await _commandDispatcher.DispatchAsync(command);
    //     return Ok();
    // }

    // [HttpPut("{SampleEntityId:guid}/items/{name}/Take")]
    // public async Task<IActionResult> Put([FromBody] TakeItem command)
    // {
    //     await _commandDispatcher.DispatchAsync(command);
    //     return Ok();
    // }

    // [HttpDelete("{SampleEntityId:guid}/items/{name}")]
    // public async Task<IActionResult> Delete([FromBody] RemoveSampleEntityItem command)
    // {
    //     await _commandDispatcher.DispatchAsync(command);
    //     return Ok();
    // }

    // [HttpDelete("{id:guid}")]
    // public async Task<IActionResult> Delete([FromBody] RemoveSampleEntity command)
    // {
    //     await _commandDispatcher.DispatchAsync(command);
    //     return Ok();
    // }
}
