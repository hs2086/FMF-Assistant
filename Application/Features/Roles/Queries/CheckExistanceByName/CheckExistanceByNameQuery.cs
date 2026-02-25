using MediatR;

namespace Application.Features.Roles.Queries.CheckExistanceByName;

public record CheckExistanceByNameQuery(string Name) : IRequest<bool>;