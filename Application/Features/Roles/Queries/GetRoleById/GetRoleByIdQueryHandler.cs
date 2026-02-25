using Application.Common.Interfaces;
using Application.Features.Roles.Command.CreateRole;
using MediatR;

namespace Application.Features.Roles.Queries.GetRoleById;

public sealed class GetRoleByIdQueryHandler(IIdentityRoleService roleService) : IRequestHandler<GetRoleByIdQuery, RoleDTO>
{

    public async Task<RoleDTO> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        return await roleService.GetRoleByIdAsync(request.Id, cancellationToken);
    }
}