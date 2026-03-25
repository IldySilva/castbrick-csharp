namespace CastBrick.SDK.Models.Sms;

public sealed class SendSmsResponse
{
    public string MessageId { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public int RecipientCount { get; set; }
    public string? Error { get; set; }
    public DateTime Timestamp { get; set; }
}
