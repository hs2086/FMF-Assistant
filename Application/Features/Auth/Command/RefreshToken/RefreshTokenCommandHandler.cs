using Application.Common.Interfaces;
using Application.Features.Auth.Command.LoginUser;
using MediatR;

namespace Application.Features.Auth.Command.RefreshToken;

public sealed class RefreshTokenCommandHandler(IIdentityAuthService authService) : IRequestHandler<RefreshTokenCommand, AuthUserDTO>
{
    public async Task<AuthUserDTO> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        return await authService.RefreshTokenAsync(request.Email, request.RefreshToken, cancellationToken);
    }
}