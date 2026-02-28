using MediatR;

namespace Application.Features.Auth.Command.SendVerificationCode;

public sealed record SendVerificationCodeCommand(string email) : IRequest;