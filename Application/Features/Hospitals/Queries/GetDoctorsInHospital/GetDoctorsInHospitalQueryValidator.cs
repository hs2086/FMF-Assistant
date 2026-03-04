using FluentValidation;

namespace Application.Features.Hospitals.Queries.GetDoctorsInHospital;

public class GetDoctorsInHospitalQueryValidator : AbstractValidator<GetDoctorsInHospitalQuery>
{
    public GetDoctorsInHospitalQueryValidator()
    {
        RuleFor(x => x.HospitalId).NotEmpty().WithMessage("Hospital ID is required.")
            .Must(id => Guid.TryParse(id, out _)).WithMessage("Invalid Hospital ID format.");
    }
}