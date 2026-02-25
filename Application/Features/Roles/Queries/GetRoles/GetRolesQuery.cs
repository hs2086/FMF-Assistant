using Application.Features.Roles.Command.CreateRole;
using MediatR;

namespace Application.Features.Roles.Queries.GetRoles;

public sealed record GetRolesQuery : IRequest<IReadOnlyList<RoleDTO>>;