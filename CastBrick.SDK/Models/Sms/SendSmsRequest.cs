namespace CastBrick.SDK.Models.Sms;

/// <summary>Request to send one or more SMS messages.</summary>
public sealed class SendSmsRequest
{
    /// <summary>List of E.164 phone numbers, e.g. "+244923000000".</summary>
    public List<string> Recipients { get; set; } = [];

    /// <summary>Message content (max 1600 characters).</summary>
    public string Content { get; set; } = string.Empty;

    /// <summary>Optional SMS sender ID.</summary>
    public string? SenderId { get; set; }

    /// <summary>Schedule the message for future delivery (UTC).</summary>
    public DateTime? ScheduledAt { get; set; }

    /// <summary>Send to all contacts in this list instead of/in addition to Recipients.</summary>
    public Guid? ContactListId { get; set; }
}
