namespace Domain;

public class Doctor
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Specialization { get; set; } = "";
    public string LicenseNumber { get; set; } = "";
    public int YearsOfExperience { get; set; } 

    public ICollection<DoctorHospital> DoctorHospitals { get; set; } = new List<DoctorHospital>();
}