namespace Application.Common.Interfaces;

public interface IIdentityHospitalService
{
    Task<Guid> CreateHospitalUserAsync(string email, string password, string name);
}