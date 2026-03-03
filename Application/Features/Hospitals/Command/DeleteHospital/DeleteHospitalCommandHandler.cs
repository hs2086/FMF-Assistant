using System.Diagnostics.CodeAnalysis;
using Application.Common.Exceptions.NotFountException;
using Application.Common.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.Hospitals.Command.DeleteHospital;

public sealed class DeleteHospitalCommandHandler(IApplicationDbContext context, IIdentityHospitalService hospitalService) : IRequestHandler<DeleteHospitalCommand>
{
    public async Task Handle(DeleteHospitalCommand request, CancellationToken cancellationToken)
    {
        Hospital? hospital = await context.Hospitals.FindAsync(request.Id, cancellationToken);
        if (hospital is null) throw new HospitalNotFoundException(request.Id);

        bool isDeleted = await hospitalService.DeleteHospitalUserAsync(hospital.Who, cancellationToken);
        if (!isDeleted) throw new HospitalNotFoundException(request.Id);

        context.Hospitals.Remove(hospital);
        await context.SaveChangesAsync(cancellationToken);
    }
}