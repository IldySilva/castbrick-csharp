namespace CastBrick.SDK.Models.Sms;

public sealed class SmsMessage
{
    public Guid Id { get; set; }
    public string? ContactName { get; set; }
    public string RecipientPhone { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public string? CampaignName { get; set; }
    public Guid? CampaignId { get; set; }
    public string? SenderId { get; set; }
    public string Status { get; set; } = string.Empty;
    public string? ErrorMessage { get; set; }
    public int RetryCount { get; set; }
    public DateTime? ScheduledAt { get; set; }
    public DateTime? SentAt { get; set; }
    public DateTime? DeliveredAt { get; set; }
}
