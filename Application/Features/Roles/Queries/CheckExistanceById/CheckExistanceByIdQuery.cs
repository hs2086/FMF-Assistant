using MediatR;

namespace Application.Features.Roles.Queries.CheckExistanceById;

public record CheckExistanceByIdQuery(Guid Id) : IRequest<bool>;