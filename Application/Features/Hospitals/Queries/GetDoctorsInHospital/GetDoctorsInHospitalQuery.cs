using Application.Features.Doctors.Queries.GetDoctorById;
using Application.Features.Doctors.Queries.GetDoctors;
using Application.Services.Pagination;
using MediatR;

namespace Application.Features.Hospitals.Queries.GetDoctorsInHospital;

public record GetDoctorsInHospitalQuery(string HospitalId, DoctorParameter Parameter) : IRequest<PagedList<DoctorDTO>>;