using Application.Features.Auth.Command.LoginUser;
using MediatR;

namespace Application.Features.Auth.Command.RefreshToken;

public sealed record RefreshTokenCommand(string Email, string RefreshToken) : IRequest<AuthUserDTO>;