using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Application.Common.Exceptions.BadRequestException;
using Application.Common.Exceptions.NotFountException;
using Application.Common.Interfaces;
using Application.Features.Auth.Command.LoginUser;
using Domain.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Infrastructure.Identity;

public class IdentityAuthService(UserManager<ApplicationUser> userManager, IApplicationDbContext context, IEmailService emailService) : IIdentityAuthService
{
    public async Task<AuthUserDTO> LoginUserAsync(string email, string password, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        ApplicationUser? user = await userManager.FindByEmailAsync(email);
        if (user == null || !await userManager.CheckPasswordAsync(user, password))
        {
            throw new UserNotFoundException(email);
        }

        if (!await userManager.IsEmailConfirmedAsync(user))
        {
            // await SendVerificationEmailAsync(email);
            throw new EmailNotVerifiedBadRequestException("Email is not verified, And we sent the verification to your email.");
        }
        
        JwtSecurityToken jwtSecurityToken = await GenerateToken(user);
        user.RefreshToken = CreateRefreshToken();
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(Convert.ToDouble(Environment.GetEnvironmentVariable("JWT__DURATIONINDAYS")));

        await userManager.UpdateAsync(user);

        return new AuthUserDTO
        {
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            Expiration = jwtSecurityToken.ValidTo.ToLocalTime(),
            RefreshToken = user.RefreshToken
        };
    }

    public async Task SendVerificationCodeAsync(string email, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user == null) throw new UserNotFoundException(email);

        var code = new Random().Next(100000, 999999).ToString();

        var verification = new EmailVerificationCode
        {
            Id = Guid.NewGuid(),
            UserId = user.Id,
            Code = code,
            ExpirationTime = DateTime.UtcNow.AddMinutes(5),
            IsUsed = false
        };

        context.EmailVerificationCodes.Add(verification);
        await context.SaveChangesAsync(cancellationToken);

        await emailService.SendEmailAsync(
            user.Email!,
            "Email Verification",
            $"Your code is {code}. It expires in 5 minutes.");
    }

    public async Task VerifyEmailCodeAsync(string email, string code, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user == null) throw new UserNotFoundException(email);

        var verification = await context.EmailVerificationCodes
            .Where(v => v.UserId == user.Id && !v.IsUsed)
            .OrderByDescending(v => v.ExpirationTime)
            .FirstOrDefaultAsync();

        if (verification == null) throw new VerificationCodeBadRequestException("No verification request found");

        if (verification.ExpirationTime < DateTime.UtcNow) throw new VerificationCodeBadRequestException("Code expired");

        if (verification.AttemptCount >= 5) throw new VerificationCodeBadRequestException("Maximum attempts reached");


        if (verification.Code != code)
        {
            verification.AttemptCount++;
            await context.SaveChangesAsync(cancellationToken);
            throw new VerificationCodeBadRequestException("Invalid code");
        }

    
        verification.IsUsed = true;

        user.EmailConfirmed = true;
        await userManager.UpdateAsync(user);

        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<AuthUserDTO> RefreshTokenAsync(string email, string refreshToken, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ApplicationUser? user = await userManager.FindByEmailAsync(email);
        if (user is null) throw new UserNotFoundException(email);

        // System.Console.WriteLine(user.RefreshToken);
        // System.Console.WriteLine(user.RefreshTokenExpiryTime);
        if (user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime < DateTime.UtcNow)
        {
            throw new RefreshTokenBadRequestException("Refresh Token is invalid!");
        }

        JwtSecurityToken jwtSecurityToken = await GenerateToken(user);
        user.RefreshToken = CreateRefreshToken();
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(Convert.ToDouble(Environment.GetEnvironmentVariable("JWT__DURATIONINDAYS")));

        await userManager.UpdateAsync(user);

        return new AuthUserDTO
        {
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            Expiration = jwtSecurityToken.ValidTo.ToLocalTime(),
            RefreshToken = user.RefreshToken
        };
    }

    public async Task ChangePasswordAsync(string oldPassword, string newPassword, string userId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        ApplicationUser? user = await userManager.FindByIdAsync(userId);
        if (user is null) throw new UserNotFoundException("User");

        await userManager.ChangePasswordAsync(user, oldPassword, newPassword);
    }

    public async Task LogoutAsync(string userId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        ApplicationUser? user = await userManager.FindByIdAsync(userId);
        if (user is null) throw new UserNotFoundException("User");

        user.RefreshToken = "invalid";
        user.RefreshTokenExpiryTime = DateTime.UtcNow;

        await userManager.UpdateAsync(user);
    }





















    // =============================================================
    private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
    {
        List<Claim> userClaims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), // <--- Add this
            new Claim(ClaimTypes.Email, user.Email ?? ""),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        IList<string> roles = await userManager.GetRolesAsync(user);
        foreach (var role in roles)
        {
            userClaims.Add(new Claim(ClaimTypes.Role, role));
        }

        SymmetricSecurityKey key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT__KEY") ?? "")
        );
        SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
            issuer: Environment.GetEnvironmentVariable("JWT__ISSUER"),
            audience: Environment.GetEnvironmentVariable("JWT__AUDIENCE"),
            claims: userClaims,
            expires: DateTime.Now.AddMinutes(
                Convert.ToDouble(Environment.GetEnvironmentVariable("JWT__DURATIONINMINUTES") ?? "60")
            ),
            signingCredentials: credentials
        );

        return jwtSecurityToken;
    }
    private string CreateRefreshToken()
    {
        return Guid.NewGuid().ToString().Replace("-", "") + Guid.NewGuid().ToString().Replace("-", "");
    }
}