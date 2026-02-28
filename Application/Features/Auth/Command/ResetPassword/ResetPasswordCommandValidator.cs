using FluentValidation;

namespace Application.Features.Auth.Command.ResetPassword;

public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
{
    public ResetPasswordCommandValidator()
    {
        RuleFor(u => u.email).NotEmpty().WithMessage("Email should not be empty!")
                             .EmailAddress().WithMessage("Email is not valid!");
        RuleFor(r => r.otp).NotEmpty().WithMessage("OTP should not be empty!")
                            .Length(6).WithMessage("OTP should be exactly 6 digits");
        RuleFor(r => r.newPassword).NotEmpty().WithMessage("Password should not be empty")
                            .MinimumLength(8).WithMessage("Password should be at least 8 characters.");
    }
}