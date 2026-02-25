namespace Application.Common.Exceptions.BadRequestExceptin.Role;

public class RoleAlreadyExistBadRequestException : BadRequestException
{
    public RoleAlreadyExistBadRequestException(string roleName) : base($"Role '{roleName}' already exists.")
    {
    }
}