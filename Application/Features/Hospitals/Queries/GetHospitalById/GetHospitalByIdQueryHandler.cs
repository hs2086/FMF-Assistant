using Application.Common.Exceptions.NotFountException;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Hospitals.Queries.GetHospitalById;

public sealed class GetHospitalByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetHospitalByIdQuery, HospitalDTO>
{
    public async Task<HospitalDTO> Handle(GetHospitalByIdQuery request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var hospital = await context.Hospitals.FindAsync(Guid.Parse(request.hospitalId), cancellationToken);
        if (hospital is null) throw new HospitalNotFoundException(request.hospitalId);

        return new HospitalDTO(
            hospital.Id,
            hospital.Name,
            hospital.Address,
            hospital.Phone,
            hospital.Email
        );
    }
}