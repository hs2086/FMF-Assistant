namespace Domain;

public class DoctorHospital
{
    public Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; } = new Doctor();

    public Guid HospitalId { get; set; }
    public Hospital Hospital { get; set; } = new Hospital();
}