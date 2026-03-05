using FluentValidation;

namespace Application.Features.Hospitals.Queries.GetHospitalStatistics;

public class GetHospitalStatisticsQueryValidator : AbstractValidator<GetHospitalStatisticsQuery>
{
    public GetHospitalStatisticsQueryValidator()
    {
        RuleFor(x => x.HospitalId)
            .NotEmpty().WithMessage("Hospital ID is required.")
            .Must(id => Guid.TryParse(id, out _)).WithMessage("Hospital ID must be a valid GUID.");
    }
}