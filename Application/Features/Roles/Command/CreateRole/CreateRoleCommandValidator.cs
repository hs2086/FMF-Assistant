using FluentValidation;

namespace Application.Features.Roles.Command.CreateRole;

public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(r => r.Name).NotEmpty().WithMessage("Name should not be empty!")
                            .MinimumLength(3).WithMessage("Name should be at least 3 characters long!");
    }
}