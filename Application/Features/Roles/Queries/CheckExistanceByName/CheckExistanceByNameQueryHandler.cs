using Application.Common.Interfaces;
using MediatR;

namespace Application.Features.Roles.Queries.CheckExistanceByName;

public sealed class CheckExistanceByNameQueryHandler(IIdentityRoleService roleService) : IRequestHandler<CheckExistanceByNameQuery, bool>
{
    public async Task<bool> Handle(CheckExistanceByNameQuery request, CancellationToken cancellationToken)
    {
        return await roleService.CheckRoleExistByName(request.Name, cancellationToken);
    }
}