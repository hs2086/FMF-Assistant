using MediatR;

namespace Application.Features.Auth.Command.LoginUser;

public sealed record LoginUserCommand(string Email, string Password) : IRequest<LoginUserDTO>;