using Application.Common.Interfaces;
using Application.Features.Roles.Command.CreateRole;
using MediatR;

namespace Application.Features.Roles.Command.UpdateRole;

public sealed class UpdateRoleCommandHandler(IIdentityRoleService roleService) : IRequestHandler<UpdateRoleCommand, RoleDTO>
{
    public async Task<RoleDTO> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        return await roleService.UpdateRoleAsync(request.Id, request.NewName, cancellationToken);
    }
}