using Application.Features.Roles.Command.CreateRole;

namespace Application.Common.Interfaces;

public interface IIdentityRoleService
{
    Task<RoleDTO> CreateRoleAsync(string roleName, CancellationToken cancellationToken);
    Task<RoleDTO> GetRoleByIdAsync(Guid roleId, CancellationToken cancellationToken);
    Task<RoleDTO> UpdateRoleAsync(Guid roleId, string newRoleName, CancellationToken cancellationToken);
    Task<RoleDTO> DeleteRoleAsync(Guid roleId, CancellationToken cancellationToken);
    Task<IReadOnlyList<RoleDTO>> GetRolesAsync(CancellationToken cancellationToken);
    Task<bool> CheckRoleExistByName(string roleName, CancellationToken cancellationToken);
    Task<bool> CheckRoleExistById(Guid roleId, CancellationToken cancellationToken);
}