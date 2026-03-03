namespace Domain;

public class PatientHospital
{
    public Guid PatientId { get; set; } 
    public Patient Patient { get; set; } = new Patient();

    public Guid HospitalId { get; set; }  
    public Hospital Hospital { get; set; } = new Hospital();
}