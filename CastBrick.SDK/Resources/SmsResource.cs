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

    /// <summary>List SMS messages with optional filters.</summary>
    public Task<PagedResult<SmsMessage>> ListAsync(
        int page = 1,
        int pageSize = 20,
        string? status = null,
        string? phone = null,
        DateTime? from = null,
        DateTime? to = null,
        CancellationToken ct = default)
    {
        var url = $"sms?pageNumber={page}&pageSize={pageSize}";
        if (!string.IsNullOrWhiteSpace(status)) url += $"&status={Uri.EscapeDataString(status)}";
        if (!string.IsNullOrWhiteSpace(phone))  url += $"&phone={Uri.EscapeDataString(phone)}";
        if (from.HasValue) url += $"&from={Uri.EscapeDataString(from.Value.ToUniversalTime().ToString("O"))}";
        if (to.HasValue)   url += $"&to={Uri.EscapeDataString(to.Value.ToUniversalTime().ToString("O"))}";
        return _client.GetAsync<PagedResult<SmsMessage>>(url, ct);
    }

    /// <summary>Cancel a scheduled SMS by its ID.</summary>
    public Task CancelScheduledAsync(Guid messageId, CancellationToken ct = default)
        => _client.DeleteAsync($"sms/{messageId}", ct);
}
