using Application.Common.Interfaces;
using MediatR;

namespace Application.Features.Roles.Queries.CheckExistanceById;

public sealed class CheckExistanceByIdQueryHandler(IIdentityRoleService roleService) : IRequestHandler<CheckExistanceByIdQuery, bool>
{
    public async Task<bool> Handle(CheckExistanceByIdQuery request, CancellationToken cancellationToken)
    {
        return await roleService.CheckRoleExistById(request.Id, cancellationToken);
    }
}