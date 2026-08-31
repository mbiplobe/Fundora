using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Donora.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    protected ActionResult<TResult> OkOrNotFound<TResult>(TResult result)
        => result is null ? NotFound() : Ok(result);
}