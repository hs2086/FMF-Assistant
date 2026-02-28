using System.Security.Claims;
using API.Request.Auth;
using Application.Features.Auth.Command.ChangePassword;
using Application.Features.Auth.Command.ForgotPassword;
using Application.Features.Auth.Command.LoginUser;
using Application.Features.Auth.Command.Logout;
using Application.Features.Auth.Command.RefreshToken;
using Application.Features.Auth.Command.ResetPassword;
using Application.Features.Auth.Command.SendVerificationCode;
using Application.Features.Auth.Command.VerifyEmail;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
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

    [HttpPost("send-otp")]
    public async Task<IActionResult> SendVerifacationCode([FromBody] SendVerificationCodeRequest request)
    {
        var command = new SendVerificationCodeCommand(request.Email);

        await mediator.Send(command);
        return Ok("Code sent successfuly.");
    }

    [HttpPost("verify")]
    public async Task<IActionResult> VerifyEmial([FromBody] VerifyEmailRequest request)
    {
        var command = new VerifyEmailCommand(request.Email, request.Code);

        await mediator.Send(command);
        return Ok("Email verified.");
    }

    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword([FromBody] Reset_PasswordRequest request)
    {
        var command = new ResetPasswordCommand(request.Email, request.Code, request.NewPassword);

        await mediator.Send(command);
        return Ok("Password has been reset successfully.");
    }

    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPassword([FromBody] Forgot_PasswordRequest request)
    {
        var command = new ForgotPasswordCommand(request.Email);

        await mediator.Send(command);
        return Ok("If an account with that email exists, a password reset otp has been sent.");
    }
}