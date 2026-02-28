using FluentValidation;

namespace Application.Features.Auth.Command.RefreshToken;

public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
{
    public RefreshTokenCommandValidator()
    {
        RuleFor(r => r.Email).NotEmpty().WithMessage("Email should not be empty!")
                             .EmailAddress().WithMessage("Email is not valid!");

        RuleFor(r => r.RefreshToken).NotEmpty().WithMessage("Refresh token should not be empty!");
    }
}