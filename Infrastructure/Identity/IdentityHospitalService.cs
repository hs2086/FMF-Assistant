using Application.Common.Exceptions.BadRequestException;
using Application.Common.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity;

public class IdentityHospitalService(UserManager<ApplicationUser> userManager) : IIdentityHospitalService
{
    public async Task<Guid> CreateHospitalUserAsync(string email, string password, string name)
    {
        ApplicationUser? userFound = await userManager.FindByEmailAsync(email);
        if (userFound is not null) throw new EmailAlreadyExistsBadRequestException("Email already exists.");

        ApplicationUser user = new ApplicationUser()
        {
            Id = Guid.NewGuid(),
            UserName = email,
            Email = email,
            FullName = name,
            EmailConfirmed = true
        };

        IdentityResult result = await userManager.CreateAsync(user, password);
        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new BadRequestException(errors);
        }

        await userManager.AddToRoleAsync(user, "Hospital");
        return user.Id;
    }

    public async Task<bool> DeleteHospitalUserAsync(Guid hospitalId, CancellationToken cancellationToken)
    {
        ApplicationUser? user = await userManager.FindByIdAsync(hospitalId.ToString());
        if (user is null) return false;
        IdentityResult result = await userManager.DeleteAsync(user);
        return result.Succeeded;
    }
}