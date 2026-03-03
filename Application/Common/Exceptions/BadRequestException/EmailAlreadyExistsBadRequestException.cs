namespace Application.Common.Exceptions.BadRequestException;

public class EmailAlreadyExistsBadRequestException(string message) : BadRequestException(message);