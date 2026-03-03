using Application.Features.Hospitals.Queries.GetHospitalById;
using Application.Services.Pagination;
using MediatR;

namespace Application.Features.Hospitals.Queries.GetHospitals;

public record GetHospitalsQuery(HospitalParameter Parameter) : IRequest<PagedList<HospitalDTO>>;