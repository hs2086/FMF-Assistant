namespace Application.Features.Auth.Command.LoginUser;

public class LoginUserDTO
{
    public string Token { get; set; } = null!;
    public DateTime Expiration { get; set; }
    public string RefreshToken { get; set; } = null!;
}