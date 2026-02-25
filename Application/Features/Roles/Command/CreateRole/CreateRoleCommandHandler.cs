using Application.Common.Interfaces;
using MediatR;

namespace Application.Features.Roles.Command.CreateRole;

public sealed class CreateRoleCommandHandler(IIdentityRoleService roleService) : IRequestHandler<CreateRoleCommand, RoleDTO>
{
    public async Task<RoleDTO> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        return await roleService.CreateRoleAsync(request.Name, cancellationToken);
    }
}