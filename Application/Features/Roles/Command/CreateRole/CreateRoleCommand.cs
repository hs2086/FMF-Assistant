using MediatR;

namespace Application.Features.Roles.Command.CreateRole;

public sealed record CreateRoleCommand(string Name) : IRequest<RoleDTO>;