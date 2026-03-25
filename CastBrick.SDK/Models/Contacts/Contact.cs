namespace CastBrick.SDK.Models.Contacts;

public sealed class Contact
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public Guid TenantId { get; set; }
    public DateTime CreatedAt { get; set; }
}
