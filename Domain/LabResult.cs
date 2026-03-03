namespace Domain;

public class LabResult
{
    public Guid Id { get; set; }
    public Guid PatientId { get; set; }
    public string TestName { get; set; } = "";
    public string ResultValue { get; set; } = "";
    public string Unit { get; set; } = "";
    public string NormalRange { get; set; } = "";
    public DateTime TestDate { get; set; }
    public string FilePath { get; set; } = "";
    public DateTime UploadedAt { get; set; }
}

