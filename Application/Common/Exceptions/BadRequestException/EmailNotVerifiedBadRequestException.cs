namespace Application.Common.Exceptions.BadRequestException;

public class EmailNotVerifiedBadRequestException(string message) : BadRequestException(message);