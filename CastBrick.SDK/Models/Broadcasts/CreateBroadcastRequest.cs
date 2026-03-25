namespace CastBrick.SDK.Models.Broadcasts;

public sealed class CreateBroadcastRequest
{
    public string Name { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public Guid? ContactListId { get; set; }
    public string? SenderId { get; set; }
}
