using Application.Common.Interfaces;
using MediatR;
using Domain;
using Application.Common.Exceptions.BadRequestException;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Hospitals.Command.CreateHospital;

public sealed class CreateHospitalCommandHandler(IApplicationDbContext context, IIdentityHospitalService hospitalService) : IRequestHandler<CreateHospitalCommand, Guid>
{
    public async Task<Guid> Handle(CreateHospitalCommand request, CancellationToken cancellationToken)
    {
        var hos = await context.Hospitals.Where(h => h.Email == request.Email).FirstOrDefaultAsync(cancellationToken);
        if (hos is not null) throw new HospitalBadRequestException("Hospital with this email already exists.");

        Guid who = await hospitalService.CreateHospitalUserAsync(request.Email, request.Password, request.Name);

        Hospital hospital = new Hospital()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Address = request.Address,
            Phone = request.Phone,
            Email = request.Email,
            UserId = Guid.Parse(request.UserId),
            Who = who
        };

        context.Hospitals.Add(hospital);
        await context.SaveChangesAsync(cancellationToken);
        return hospital.Id;
    }
}