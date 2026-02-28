using FluentValidation;

namespace Application.Features.Auth.Command.VerifyEmail;

public class VerifyEmailCommandValidator : AbstractValidator<VerifyEmailCommand>
{
    public VerifyEmailCommandValidator()
    {
        RuleFor(u => u.email).NotEmpty().WithMessage("Email should not be empty!")
                             .EmailAddress().WithMessage("Email is not valid!");
        RuleFor(u => u.code).NotEmpty().WithMessage("Code should not be empty!");
    }
}