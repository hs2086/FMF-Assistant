using Application.Common.Interfaces;
using MediatR;

namespace Application.Features.Auth.Command.VerifyEmail;

public sealed class VerifyEmailCommandHandler(IIdentityAuthService authService) : IRequestHandler<VerifyEmailCommand>
{
    public async Task Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
    {
        await authService.VerifyEmailCodeAsync(request.email, request.code, cancellationToken);
    }
}