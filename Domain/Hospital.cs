namespace Domain;

public class Hospital
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public string Address { get; set; } = "";
    public string Phone { get; set; } = "";
    public string Email { get; set; } = "";
    public Guid UserId { get; set; }

    public ICollection<DoctorHospital> DoctorHospitals { get; set; } = new List<DoctorHospital>();
    public ICollection<PatientHospital> PatientHospitals { get; set; } = new List<PatientHospital>();
}