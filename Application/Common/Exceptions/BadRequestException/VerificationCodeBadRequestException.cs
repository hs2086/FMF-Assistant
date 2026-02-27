namespace Application.Common.Exceptions.BadRequestException;

public class VerificationCodeBadRequestException(string message) : BadRequestException(message);