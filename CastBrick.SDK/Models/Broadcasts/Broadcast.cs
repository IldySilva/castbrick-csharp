namespace CastBrick.SDK.Models.Broadcasts;

public sealed class Broadcast
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string? SenderId { get; set; }
    public Guid? ContactListId { get; set; }
    public DateTime? ScheduledAt { get; set; }
    public Guid TenantId { get; set; }
    public DateTime CreatedAt { get; set; }
}
