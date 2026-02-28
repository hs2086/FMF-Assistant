using API.Request.Auth;
using Application.Features.Auth.Command.LoginUser;
using Application.Features.Auth.Command.RefreshToken;
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

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshTokenAsync([FromBody] RefreshTokenRequest request)
    {
        var command = new RefreshTokenCommand(request.Email, request.RefreshToken);

        var response = await mediator.Send(command);
        return Ok(response);
    }
}