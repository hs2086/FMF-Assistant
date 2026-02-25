using Application.Common.Exceptions.BadRequestExceptin;
using Application.Common.Exceptions.BadRequestExceptin.Role;
using Application.Common.Interfaces;
using Application.Features.Roles.Command.CreateRole;
using Microsoft.AspNetCore.Identity;

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



    
}