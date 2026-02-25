using Application.Common.Interfaces;
using Application.Features.Roles.Command.CreateRole;
using MediatR;

namespace Application.Features.Roles.Queries.GetRoles;

public sealed class GetRolesQueryHandler(IIdentityRoleService roleService) : IRequestHandler<GetRolesQuery, IReadOnlyList<RoleDTO>>
{
    public async Task<IReadOnlyList<RoleDTO>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        return await roleService.GetRolesAsync(cancellationToken);
    }
}