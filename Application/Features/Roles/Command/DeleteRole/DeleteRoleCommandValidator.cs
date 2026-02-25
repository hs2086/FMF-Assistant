using FluentValidation;

namespace Application.Features.Roles.Command.DeleteRole;

public class DeleteRoleCommandValidator : AbstractValidator<DeleteRoleCommand>
{
    public DeleteRoleCommandValidator()
    {
        RuleFor(r => r.Id).NotEqual(Guid.Empty).WithMessage("Id should not be empty!");
    }
}