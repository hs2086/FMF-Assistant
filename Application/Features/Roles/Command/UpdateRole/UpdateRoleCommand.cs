using Application.Features.Roles.Command.CreateRole;
using MediatR;

namespace Application.Features.Roles.Command.UpdateRole;

public sealed record UpdateRoleCommand(Guid Id, string NewName) : IRequest<RoleDTO>;