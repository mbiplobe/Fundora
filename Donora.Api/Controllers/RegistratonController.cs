using Microsoft.AspNetCore.Mvc;
using Donora.Api.Controllers;
using Donora.Shared.Abstractions.Commands;
using Donora.Shared.Abstractions.Queries;

public class RegistratonController : BaseController
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public RegistratonController(
        ICommandDispatcher commandDispatcher,
        IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpPost]
    public async Task<IActionResult> SignUp([FromBody] SignUpCommand command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok(true);
    }

   
}