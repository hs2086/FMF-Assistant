using Application.Common.Interfaces;
using MediatR;

namespace Application.Features.Auth.Command.SendVerificationCode;


public sealed class SendVerificationCodeCommandHandler(IIdentityAuthService authService) : IRequestHandler<SendVerificationCodeCommand>
{
    public async Task Handle(SendVerificationCodeCommand request, CancellationToken cancellationToken)
    {
        await authService.SendVerificationCodeAsync(request.email, cancellationToken);
    }
}