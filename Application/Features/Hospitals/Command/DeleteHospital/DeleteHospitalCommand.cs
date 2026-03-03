using MediatR;

namespace Application.Features.Hospitals.Command.DeleteHospital;

public record DeleteHospitalCommand(string Id) : IRequest;