namespace Application.Common.Exceptions.BadRequestException;

public sealed class ResetPasswordBadRequestException(string message) : BadRequestException(message);