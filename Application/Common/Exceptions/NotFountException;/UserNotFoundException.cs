namespace Application.Common.Exceptions.NotFountException;

public class UserNotFoundException(string email) : NotFoundException($"{email} not found.");