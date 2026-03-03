using FluentValidation;

namespace Application.Features.Hospitals.Command.UpdateHospital;

public class UpdateHospitalCommandValidator : AbstractValidator<UpdateHospitalCommand>
{
    public UpdateHospitalCommandValidator()
    {
        RuleFor(x => x.name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

        RuleFor(x => x.address)
            .NotEmpty().WithMessage("Address is required.")
            .MaximumLength(200).WithMessage("Address cannot exceed 200 characters.");

        RuleFor(x => x.phone)
            .NotEmpty().WithMessage("Phone is required.");

        RuleFor(x => x.email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email must be a valid email address.");
        
        RuleFor(x => x.hospitalId)
            .NotEmpty().WithMessage("Hospital id is required.")
            .Must(hospitalId => Guid.TryParse(hospitalId, out _)).WithMessage("Hospital id must be a valid GUID.");
    }
}