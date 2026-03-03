using FluentValidation;

namespace Application.Features.Hospitals.Command.DeleteHospital;

public class DeleteHospitalCommandValidator : AbstractValidator<DeleteHospitalCommand>
{
    public DeleteHospitalCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.")
            .Must(id => Guid.TryParse(id, out _)).WithMessage("Id must be a valid GUID.");
    }
}