using API.Request.Auth;
using Application.Features.Auth.Command.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginUserRequest request)
    {
        var command = new LoginUserCommand(request.Email, request.Password);

        var response = await mediator.Send(command);
        return Ok(response);
    }
}