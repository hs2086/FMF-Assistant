namespace Domain;

public class Patient
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }    
    public string NationalId { get; set; } = "";
    public DateTime DateOfBirth { get; set; }
    public char Gender { get; set; }
    public decimal Weight { get; set; } 
    public decimal Height { get; set; }
    public DateTime DiagnosisDate { get; set; }

    public ICollection<PatientHospital> PatientHospitals { get; set; } = new List<PatientHospital>();
}