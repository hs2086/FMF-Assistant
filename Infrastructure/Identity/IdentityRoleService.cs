using Application.Common.Exceptions.BadRequestException;
using Application.Common.Exceptions.BadRequestException.Role;
using Application.Common.Exceptions.NotFountException.Role;
using Application.Common.Interfaces;
using Application.Features.Roles.Command.CreateRole;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Identity;

public class IdentityRoleService(RoleManager<IdentityRole<Guid>> roleManager) : IIdentityRoleService
{
    public async Task<RoleDTO> CreateRoleAsync(string roleName, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var normalizedRoleName = roleName.Trim().ToLower();
        bool roleExist = await roleManager.RoleExistsAsync(normalizedRoleName);
        if (roleExist)  
        {
            throw new RoleAlreadyExistBadRequestException(roleName);
        }
        IdentityRole<Guid> role = new IdentityRole<Guid>
        {
            Id = Guid.NewGuid(),
            Name = roleName.Trim(),
            NormalizedName = normalizedRoleName
        };
        IdentityResult result = await roleManager.CreateAsync(role);
        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new BadRequestException(errors);
        }

        return new RoleDTO(role.Id, role.Name);
    }

    public async Task<RoleDTO> DeleteRoleAsync(Guid roleId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        IdentityRole<Guid>? role = await roleManager.FindByIdAsync(roleId.ToString());
        if (role == null)
        {
            throw new RoleNotFoundException(roleId);
        }
        IdentityResult result = await roleManager.DeleteAsync(role);
        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new BadRequestException(errors);
        }
        return new RoleDTO(role.Id, role.Name ?? "default");
    }

    public async Task<bool> CheckRoleExistById(Guid roleId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        IdentityRole<Guid>? role = await roleManager.FindByIdAsync(roleId.ToString());
        return role != null;
    }

    public async Task<bool> CheckRoleExistByName(string roleName, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var normalizedRoleName = roleName.Trim().ToLower();
        IdentityRole<Guid>? role = await roleManager.FindByNameAsync(normalizedRoleName);
        return role != null;
    }

    public async Task<RoleDTO> GetRoleByIdAsync(Guid roleId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        IdentityRole<Guid>? role = await roleManager.FindByIdAsync(roleId.ToString());
        if (role is null)
            throw new RoleNotFoundException(roleId);
        return new RoleDTO(role.Id, role.Name ?? "default");
    }

    public async Task<RoleDTO> UpdateRoleAsync(Guid roleId, string newRoleName, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        IdentityRole<Guid>? role = await roleManager.FindByIdAsync(roleId.ToString());
        if (role is null)
            throw new RoleNotFoundException(roleId);
        
        role.Name = newRoleName.Trim();
        role.NormalizedName = newRoleName.Trim().ToLower();
        IdentityResult result = await roleManager.UpdateAsync(role);
        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new BadRequestException(errors);
        }
        return new RoleDTO(role.Id, role.Name ?? "default");
    }

    public async Task<IReadOnlyList<RoleDTO>> GetRolesAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var roles = await roleManager.Roles.OrderBy(r => r.Name).Select(r => new RoleDTO(r.Id, r.Name ?? "default")).ToListAsync(cancellationToken);
        return roles;
    }
}