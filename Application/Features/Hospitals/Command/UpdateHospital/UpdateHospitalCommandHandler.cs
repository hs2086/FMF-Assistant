using Application.Common.Exceptions.NotFountException;
using Application.Common.Interfaces;
using Application.Features.Hospitals.Queries.GetHospitalById;
using MediatR;

namespace Application.Features.Hospitals.Command.UpdateHospital;

public sealed class UpdateHospitalCommandHandler(IApplicationDbContext context) : IRequestHandler<UpdateHospitalCommand, HospitalDTO>
{
    public async Task<HospitalDTO> Handle(UpdateHospitalCommand request, CancellationToken cancellationToken)
    {
        var hospital = await context.Hospitals.FindAsync(Guid.Parse(request.hospitalId), cancellationToken);
        if (hospital is null) throw new HospitalNotFoundException(request.hospitalId);

        hospital.Name = request.name;
        hospital.Address = request.address;
        hospital.Phone = request.phone;
        hospital.Email = request.email;

        await context.SaveChangesAsync(cancellationToken);
        return new HospitalDTO(
            hospital.Id,
            hospital.Name,
            hospital.Address,
            hospital.Phone,
            hospital.Email
        );
    }
}