using Application.Features.Auth.Command.LoginUser;

namespace Application.Common.Interfaces;

public interface IIdentityAuthService
{
    Task<AuthUserDTO> LoginUserAsync(string email, string password, CancellationToken cancellationToken);
    Task<AuthUserDTO> RefreshTokenAsync(string email, string refreshToken, CancellationToken cancellationToken);
    Task ChangePasswordAsync(string oldPassword, string newPassword, string userId, CancellationToken cancellationToken);
}