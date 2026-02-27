using FluentValidation;

namespace Application.Features.Auth.Command.LoginUser;

public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(u => u.Email).NotEmpty().WithMessage("Email should not be empty!")
                             .EmailAddress().WithMessage("Email is not valid!");
        RuleFor(u => u.Password).NotEmpty().WithMessage("Password should not be empty!")
                                .MinimumLength(8).WithMessage("Password should be at least 8 characters long!");
    }
}   