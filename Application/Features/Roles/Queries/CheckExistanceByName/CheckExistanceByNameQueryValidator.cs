using FluentValidation;

namespace Application.Features.Roles.Queries.CheckExistanceByName;

public class CheckExistanceByNameQueryValidator : AbstractValidator<CheckExistanceByNameQuery>
{
    public CheckExistanceByNameQueryValidator()
    {
        RuleFor(r => r.Name).NotEmpty().WithMessage("Name should not be empty!")
                            .MinimumLength(3).WithMessage("Name should be at least 3 characters long!");
    }
}