using CastBrick.SDK.Models;
using CastBrick.SDK.Models.Sms;

namespace CastBrick.SDK.Resources;

/// <summary>SMS operations.</summary>
public sealed class SmsResource
{
    private readonly CastBrickHttpClient _client;

    internal SmsResource(CastBrickHttpClient client) => _client = client;

    /// <summary>Send an SMS to one or more recipients.</summary>
    public Task<SendSmsResponse> SendAsync(SendSmsRequest request, CancellationToken ct = default)
        => _client.PostAsync<SendSmsResponse>("sms/send", request, ct);

    /// <summary>Get a single SMS message by ID.</summary>
    public Task<SmsMessage> GetAsync(Guid id, CancellationToken ct = default)
        => _client.GetAsync<SmsMessage>($"sms/{id}", ct);

    /// <summary>List SMS messages (paginated).</summary>
    public Task<PagedResult<SmsMessage>> ListAsync(int page = 1, int pageSize = 20, CancellationToken ct = default)
        => _client.GetAsync<PagedResult<SmsMessage>>($"sms?pageNumber={page}&pageSize={pageSize}", ct);

    /// <summary>Cancel a scheduled SMS.</summary>
    public Task CancelScheduledAsync(Guid messageId, CancellationToken ct = default)
        => _client.PostAsync("sms/cancel-scheduled", new { messageId }, ct);
}
