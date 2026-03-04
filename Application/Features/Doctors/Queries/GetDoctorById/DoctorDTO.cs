namespace Application.Features.Doctors.Queries.GetDoctorById;

public record DoctorDTO(string Id, string Name, string Specialty, string Phone, string Email, string HospitalId);