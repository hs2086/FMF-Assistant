using Application.Common.Interfaces;
using MediatR;

namespace Application.Features.Auth.Command.ResetPassword;

public sealed class ResetPasswordCommandHandler(IIdentityAuthService authService) : IRequestHandler<ResetPasswordCommand>
{
    public async Task Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        await authService.ResetPasswordAsync(request.email, request.otp, request.newPassword, cancellationToken);
    }
}