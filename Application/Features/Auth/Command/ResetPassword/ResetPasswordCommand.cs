using MediatR;

namespace Application.Features.Auth.Command.ResetPassword;

public sealed record ResetPasswordCommand(string email, string otp, string newPassword) : IRequest;