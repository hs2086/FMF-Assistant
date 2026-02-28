using FluentValidation;

namespace Application.Features.Auth.Command.SendVerificationCode;

public class SendVerificationCodeCommandValidator : AbstractValidator<SendVerificationCodeCommand>
{
    public SendVerificationCodeCommandValidator()
    {
        RuleFor(u => u.email).NotEmpty().WithMessage("Email should not be empty!")
                             .EmailAddress().WithMessage("Email is not valid!");
    }
}