namespace Domain;

public class Attack
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; } = new Patient();

    public DateTime Date { get; set; }  
    public int Severity { get; set; }   
    public int DurationHours { get; set; }
    public string Symptoms { get; set; } = "";
    public string Notes { get; set; } = "";
    public DateTime CreatedAt => DateTime.UtcNow;
}