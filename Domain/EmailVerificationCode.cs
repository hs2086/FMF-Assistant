namespace Domain;

public class EmailVerificationCode
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    
    public string Code { get; set; } = default!;

    public DateTime ExpirationTime { get; set; }

    public int AttemptCount { get; set; } = 0;

    public bool IsUsed { get; set; } = false;
}