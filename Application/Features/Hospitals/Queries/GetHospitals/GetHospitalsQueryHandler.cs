using Application.Common.Interfaces;
using Application.Features.Hospitals.Queries.GetHospitalById;
using Application.Services.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Hospitals.Queries.GetHospitals;

public sealed class GetHospitalsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetHospitalsQuery, PagedList<HospitalDTO>>
{
    public async Task<PagedList<HospitalDTO>> Handle(GetHospitalsQuery request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var query = await context.Hospitals.AsNoTracking().Select(h => new HospitalDTO
        (
            h.Id,
            h.Name,
            h.Address,
            h.Phone,
            h.Email
        )).ToListAsync(cancellationToken);

        return PagedList<HospitalDTO>.ToPagedList(query, request.Parameter.PageNumber, request.Parameter.PageSize);
    }
}