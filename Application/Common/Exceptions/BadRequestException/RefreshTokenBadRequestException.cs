namespace Application.Common.Exceptions.BadRequestException;

public sealed class RefreshTokenBadRequestException(string message) : BadRequestException(message);