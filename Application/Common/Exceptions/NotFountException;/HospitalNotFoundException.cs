namespace Application.Common.Exceptions.NotFountException;

public sealed class HospitalNotFoundException(string hospitalId) : NotFoundException($"Hospital '{hospitalId}' not found.");