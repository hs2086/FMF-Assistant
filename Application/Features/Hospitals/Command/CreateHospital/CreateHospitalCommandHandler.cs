using Application.Common.Interfaces;
using MediatR;
using Domain;

namespace Application.Features.Hospitals.Command.CreateHospital;

public sealed class CreateHospitalCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateHospitalCommand, Guid>
{
    public async Task<Guid> Handle(CreateHospitalCommand request, CancellationToken cancellationToken)
    {
        Hospital hospital = new Hospital()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Address = request.Address,
            Phone = request.Phone,
            Email = request.Email,
            UserId = Guid.Parse(request.UserId)
        };

        context.Hospitals.Add(hospital);
        await context.SaveChangesAsync(cancellationToken);
        return hospital.Id;
    }
}