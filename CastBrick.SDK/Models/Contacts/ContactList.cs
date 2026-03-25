namespace CastBrick.SDK.Models.Contacts;

public sealed class ContactList
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid TenantId { get; set; }
    public int ContactCount { get; set; }
    public DateTime CreatedAt { get; set; }
}
