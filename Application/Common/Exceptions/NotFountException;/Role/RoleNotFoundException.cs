namespace Application.Common.Exceptions.NotFountException.Role;

public class RoleNotFoundException(Guid roleId) : NotFoundException($"Role with ID '{roleId}' was not found.");