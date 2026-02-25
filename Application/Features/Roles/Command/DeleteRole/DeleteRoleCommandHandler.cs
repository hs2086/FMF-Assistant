using Application.Common.Interfaces;
using Application.Features.Roles.Command.CreateRole;
using MediatR;

namespace Application.Features.Roles.Command.DeleteRole;

public sealed class DeleteRoleCommandHandler(IIdentityRoleService _roleService) : IRequestHandler<DeleteRoleCommand, RoleDTO>
{
    public async Task<RoleDTO> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        return await _roleService.DeleteRoleAsync(request.Id, cancellationToken);
    }
}