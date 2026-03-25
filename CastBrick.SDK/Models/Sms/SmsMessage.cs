namespace CastBrick.SDK.Models.Sms;

public sealed class SmsMessage
{
    public Guid Id { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public Guid TenantId { get; set; }
    public DateTime? SentAt { get; set; }
    public DateTime? DeliveredAt { get; set; }
    public DateTime CreatedAt { get; set; }
}
