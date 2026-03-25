using CastBrick.SDK.Resources;

namespace CastBrick.SDK;

/// <summary>
/// Official CastBrick .NET SDK client.
/// <para>
/// <example>
/// <code>
/// var cb = new CastBrickClient(new CastBrickOptions { ApiKey = "your_api_key" });
///
/// // Send an SMS
/// await cb.Sms.SendAsync(new SendSmsRequest
/// {
///     Recipients = ["+244923000000"],
///     Content = "Hello from CastBrick!"
/// });
///
/// // List contacts
/// var contacts = await cb.Contacts.ListAsync();
///
/// // Create and send a broadcast
/// var id = await cb.Broadcasts.CreateAsync(new CreateBroadcastRequest
/// {
///     Name = "Promo",
///     Message = "50% off today!"
/// });
/// await cb.Broadcasts.SendAsync(id);
/// </code>
/// </example>
/// </para>
/// </summary>
public sealed class CastBrickClient
{
    /// <summary>SMS operations.</summary>
    public SmsResource Sms { get; }

    /// <summary>Contacts and contact lists operations.</summary>
    public ContactsResource Contacts { get; }

    /// <summary>Broadcast operations.</summary>
    public BroadcastsResource Broadcasts { get; }

    /// <summary>
    /// Initialise the CastBrick client with an <see cref="HttpClient"/> and options.
    /// Use this overload when integrating with <c>IHttpClientFactory</c>.
    /// </summary>
    public CastBrickClient(HttpClient httpClient, CastBrickOptions options)
    {
        var client = new CastBrickHttpClient(httpClient, options);
        Sms = new SmsResource(client);
        Contacts = new ContactsResource(client);
        Broadcasts = new BroadcastsResource(client);
    }

    /// <summary>
    /// Initialise the CastBrick client with a new <see cref="HttpClient"/> (standalone usage).
    /// </summary>
    public CastBrickClient(CastBrickOptions options)
        : this(new HttpClient(), options) { }
}
