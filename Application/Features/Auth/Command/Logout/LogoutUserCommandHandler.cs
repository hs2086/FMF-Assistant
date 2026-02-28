using Application.Common.Interfaces;
using MediatR;

namespace Application.Features.Auth.Command.Logout;

public sealed class LogoutUserCommandHandler(IIdentityAuthService authService) : IRequestHandler<LogoutUserCommand>
{
    public async Task Handle(LogoutUserCommand request, CancellationToken cancellationToken)
    {
        await authService.LogoutAsync(request.userId, cancellationToken);
    }
}