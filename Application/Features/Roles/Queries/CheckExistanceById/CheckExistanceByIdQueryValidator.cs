using FluentValidation;

namespace Application.Features.Roles.Queries.CheckExistanceById;

public class CheckExistanceByIdQueryValidator : AbstractValidator<CheckExistanceByIdQuery>
{
    public CheckExistanceByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Role ID must not be empty.");
    }
}