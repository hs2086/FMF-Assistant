using Application.Features.Roles.Command.CreateRole;
using MediatR;

namespace Application.Features.Roles.Command.DeleteRole;

public sealed record DeleteRoleCommand(Guid Id) : IRequest<RoleDTO>;