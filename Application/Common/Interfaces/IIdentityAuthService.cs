using Application.Features.Auth.Command.LoginUser;

namespace Application.Common.Interfaces;

public interface IIdentityAuthService
{
    Task<LoginUserDTO> LoginUserAsync(string email, string password, CancellationToken cancellationToken);
}