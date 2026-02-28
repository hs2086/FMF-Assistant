using FluentValidation;

namespace Application.Features.Auth.Command.ChangePassword;

public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
{
    public ChangePasswordCommandValidator()
    {
        RuleFor(u => u.oldPassword).NotEmpty().WithMessage("Password should not be empty!")
                                .MinimumLength(8).WithMessage("Password should be at least 8 characters long!");
        RuleFor(u => u.newPassword).NotEmpty().WithMessage("New password should not be empty!")
                                .MinimumLength(8).WithMessage("New password should be at least 8 characters long!");
    }
}