using MediatR;

namespace Application.Features.Auth.Command.Logout;

public sealed record LogoutUserCommand(string userId) : IRequest;