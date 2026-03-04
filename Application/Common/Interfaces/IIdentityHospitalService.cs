using Application.Features.Doctors.Queries.GetDoctorById;

namespace Application.Common.Interfaces;

public interface IIdentityHospitalService
{
    Task<Guid> CreateHospitalUserAsync(string email, string password, string name);
    Task<bool> DeleteHospitalUserAsync(Guid hospitalId, CancellationToken cancellationToken);
    Task<List<DoctorDTO>> GetDoctorsInHospitalAsync(Guid hospitalId, CancellationToken cancellationToken);
}