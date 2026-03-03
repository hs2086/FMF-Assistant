using Application.Features.Hospitals.Queries.GetHospitalById;
using MediatR;

namespace Application.Features.Hospitals.Command.UpdateHospital;

public sealed record UpdateHospitalCommand(string hospitalId,string name, string address, string phone, string email) : IRequest<HospitalDTO>;