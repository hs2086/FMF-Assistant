using FluentValidation;

namespace Application.Features.Roles.Command.UpdateRole;

public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
{
    public UpdateRoleCommandValidator()
    {
        RuleFor(r => r.Id).NotEqual(Guid.Empty).WithMessage("Id should not be empty!");
        
        RuleFor(r => r.NewName).NotEmpty().WithMessage("Name should not be empty!")
                            .MinimumLength(3).WithMessage("Name should be at least 3 characters long!");
    }
}