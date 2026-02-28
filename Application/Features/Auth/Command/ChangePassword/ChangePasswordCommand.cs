using MediatR;

namespace Application.Features.Auth.Command.ChangePassword;

public sealed record ChangePasswordCommand(string oldPassword, string newPassword, string userId) : IRequest;
