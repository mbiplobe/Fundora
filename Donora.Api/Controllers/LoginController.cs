using Microsoft.AspNetCore.Mvc;
using Donora.Api.Controllers;
using Donora.Shared.Abstractions.Commands;
using Donora.Shared.Abstractions.Queries;

// public class LoginController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher) : BaseController
// {
//     // [HttpPost]
//     // public async Task<IActionResult> Login(LoginCommand command)
//     // {
//     //     //var result = await commandDispatcher.DispatchAsync(command);
//     //     return OkOrNotFound(result);
//     // }

//     // [HttpPost]
//     // public async Task<IActionResult> Login(LoginCommand command)
//     // {
//     //     // var result = await commandDispatcher.DispatchAsync(command);
//     //     return OkOrNotFound(null);
//     // }
// }