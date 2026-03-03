using FluentValidation;

namespace Application.Features.Hospitals.Queries.GetHospitalById;

public class GetHospitalByIdQueryValidator : AbstractValidator<GetHospitalByIdQuery>
{
    public GetHospitalByIdQueryValidator()
    {
        RuleFor(x => x.hospitalId)
            .NotEmpty().WithMessage("Hospital Id is required.")
            .Must(id => Guid.TryParse(id, out _)).WithMessage("Hospital Id must be a valid GUID.");
    }
}