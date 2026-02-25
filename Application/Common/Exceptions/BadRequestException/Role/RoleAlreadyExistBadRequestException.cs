namespace Application.Common.Exceptions.BadRequestException.Role;

public class RoleAlreadyExistBadRequestException : BadRequestException
{
    public RoleAlreadyExistBadRequestException(string roleName) : base($"Role '{roleName}' already exists.")
    {
    }
}