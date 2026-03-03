using MediatR;

namespace Application.Features.Hospitals.Command.CreateHospital;

public record CreateHospitalCommand(
    string Name,
    string Address,
    string Phone,
    string Email,
    string UserId,
    string Password
) : IRequest<Guid>;