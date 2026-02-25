using Application.Features.Roles.Command.CreateRole;
using MediatR;

namespace Application.Features.Roles.Queries.GetRoleById;

public sealed record GetRoleByIdQuery(Guid Id) : IRequest<RoleDTO>;