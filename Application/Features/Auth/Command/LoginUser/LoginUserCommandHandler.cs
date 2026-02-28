using Application.Common.Interfaces;
using MediatR;

namespace Application.Features.Auth.Command.LoginUser;

public class LoginUserCommandHandler(IIdentityAuthService authService) : IRequestHandler<LoginUserCommand, AuthUserDTO>
{
    public async Task<AuthUserDTO> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        return await authService.LoginUserAsync(request.Email, request.Password, cancellationToken);
    }
}