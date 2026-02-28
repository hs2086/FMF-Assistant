using System.Security.Claims;
using API.Request.Auth;
using Application.Features.Auth.Command.ChangePassword;
using Application.Features.Auth.Command.LoginUser;
using Application.Features.Auth.Command.Logout;
using Application.Features.Auth.Command.RefreshToken;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

    [HttpPost("change-password")]
    [Authorize]
    public async Task<IActionResult> ChangePasswordAsync([FromBody] ChangePasswordRequest request)
    {
        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId is null) return BadRequest("Login first!");
        var command = new ChangePasswordCommand(request.OldPassword, request.NewPassword, userId);

        await mediator.Send(command);
        return Ok("Password changed successfully.");
    }

    [HttpPost("logout")]
    [Authorize]
    public async Task<IActionResult> LogoutAsync()
    {
        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId is null) return Unauthorized();

        var command = new LogoutUserCommand(userId);

        await mediator.Send(command);
        return Ok("Logout is successfully.");
    }
}