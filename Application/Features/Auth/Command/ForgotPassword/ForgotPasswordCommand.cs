using MediatR;

namespace Application.Features.Auth.Command.ForgotPassword;

public sealed record ForgotPasswordCommand(string email) : IRequest;