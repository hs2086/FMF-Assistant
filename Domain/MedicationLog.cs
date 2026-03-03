namespace Domain;

public class MedicationLog
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; } = new Patient();
    public DateTime Date { get; set; }
    public bool Taken { get; set; } 
    public string Dose { get; set; } = "";
    public string Notes { get; set; } = "";
}