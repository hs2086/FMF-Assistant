using Application.Common.Interfaces;
using MediatR;

namespace Application.Features.Auth.Command.ForgotPassword;

public sealed class ForgotPasswordCommandHandler(IIdentityAuthService authService) : IRequestHandler<ForgotPasswordCommand>
{
    public async Task Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        await authService.ForgotPasswordAsync(request.email, cancellationToken);
    }
}