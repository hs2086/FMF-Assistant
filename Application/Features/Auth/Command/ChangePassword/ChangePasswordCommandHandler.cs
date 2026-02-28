using Application.Common.Interfaces;
using MediatR;

namespace Application.Features.Auth.Command.ChangePassword;

public sealed class ChangePasswordCommandHandler(IIdentityAuthService authService) : IRequestHandler<ChangePasswordCommand>
{
    public async Task Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        await authService.ChangePasswordAsync(request.oldPassword, request.newPassword, request.userId, cancellationToken);
    }
}