using Application.Common.Interfaces;
using Application.Features.Doctors.Queries.GetDoctorById;
using Application.Services.Pagination;
using MediatR;

namespace Application.Features.Hospitals.Queries.GetDoctorsInHospital;

public sealed class GetDoctorsInHospitalQueryHandler(IIdentityHospitalService hospitalService)
: IRequestHandler<GetDoctorsInHospitalQuery, PagedList<DoctorDTO>>
{
    // string Id, string Name, string Specialty, string Phone, string Email, string HospitalId
    public async Task<PagedList<DoctorDTO>> Handle(GetDoctorsInHospitalQuery request, CancellationToken cancellationToken)
    {
        return PagedList<DoctorDTO>.ToPagedList(
            await hospitalService.GetDoctorsInHospitalAsync(Guid.Parse(request.HospitalId), cancellationToken), 
            request.Parameter.PageNumber, 
            request.Parameter.PageSize);
    }
}