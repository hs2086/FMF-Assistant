using MediatR;

namespace Application.Features.Auth.Command.VerifyEmail;

public sealed record VerifyEmailCommand(string email, string code) : IRequest;