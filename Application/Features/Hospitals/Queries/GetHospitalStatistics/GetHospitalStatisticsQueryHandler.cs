using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Application.Common.Exceptions.NotFountException;

namespace Application.Features.Hospitals.Queries.GetHospitalStatistics;

public sealed class GetHospitalStatisticsQueryHandler(IApplicationDbContext context) :IRequestHandler<GetHospitalStatisticsQuery, HospitalStatisticsDTO>
{
    public async Task<HospitalStatisticsDTO> Handle(GetHospitalStatisticsQuery request, CancellationToken cancellationToken)
    {
        var hospital = await context.Hospitals.FirstOrDefaultAsync(h => h.Id == Guid.Parse(request.HospitalId), cancellationToken);

        if (hospital is null) throw new HospitalNotFoundException(request.HospitalId);

        var statistics = new HospitalStatisticsDTO
        (
            await context.DoctorHospital.Where(dh => dh.HospitalId == Guid.Parse(request.HospitalId)).CountAsync(cancellationToken),
            await context.PatientHospital.Where(ph => ph.HospitalId == Guid.Parse(request.HospitalId)).CountAsync(cancellationToken)
        );

        return statistics;
    }
}