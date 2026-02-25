namespace API.Request.Role;

public class UpdateRoleRequest
{
    public Guid Id { get; set; }
    public string NewName { get; set; } = string.Empty;
}