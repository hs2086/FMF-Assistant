using MediatR;

namespace Application.Features.Hospitals.Queries.GetHospitalById;

public record GetHospitalByIdQuery(string hospitalId) : IRequest<HospitalDTO>;