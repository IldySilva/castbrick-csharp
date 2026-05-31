namespace CastBrick.SDK.Models.Contacts;

public sealed class CreateContactRequest
{
    /// <summary>Comma or newline-separated phone numbers.</summary>
    public string? PhoneNumbers { get; set; }
}
