namespace API.Request.Auth;

public class RefreshTokenRequest
{
    public string Email { get; set; } = default!;
    public string RefreshToken { get; set; } = default!;
}