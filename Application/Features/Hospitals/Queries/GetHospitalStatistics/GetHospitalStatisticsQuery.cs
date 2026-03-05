using MediatR;

namespace Application.Features.Hospitals.Queries.GetHospitalStatistics;

public record GetHospitalStatisticsQuery(string HospitalId) : IRequest<HospitalStatisticsDTO>;