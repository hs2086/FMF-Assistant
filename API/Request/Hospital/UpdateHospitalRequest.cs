namespace API.Request.Hospital;

public class UpdateHospitalRequest
{
    public string name { get; set; } = null!;
    public string address { get; set; } = null!;
    public string phone { get; set; } = null!;
    public string email { get; set; } = null!;
}