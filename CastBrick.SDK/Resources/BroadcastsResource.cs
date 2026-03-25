using CastBrick.SDK.Models;
using CastBrick.SDK.Models.Broadcasts;

namespace CastBrick.SDK.Resources;

/// <summary>Broadcast operations.</summary>
public sealed class BroadcastsResource
{
    private readonly CastBrickHttpClient _client;

    internal BroadcastsResource(CastBrickHttpClient client) => _client = client;

    /// <summary>List broadcasts (paginated).</summary>
    public Task<PagedResult<Broadcast>> ListAsync(int page = 1, int pageSize = 20, CancellationToken ct = default)
        => _client.GetAsync<PagedResult<Broadcast>>($"broadcasts?pageNumber={page}&pageSize={pageSize}", ct);

    /// <summary>Get a broadcast by ID.</summary>
    public Task<Broadcast> GetAsync(Guid id, CancellationToken ct = default)
        => _client.GetAsync<Broadcast>($"broadcasts/{id}", ct);

    /// <summary>Create a new broadcast. Returns the new broadcast ID.</summary>
    public Task<Guid> CreateAsync(CreateBroadcastRequest request, CancellationToken ct = default)
        => _client.PostAsync<Guid>("broadcasts", request, ct);

    /// <summary>Update an existing broadcast.</summary>
    public Task<Guid> UpdateAsync(Guid id, UpdateBroadcastRequest request, CancellationToken ct = default)
        => _client.PutAsync<Guid>($"broadcasts/{id}", request, ct);

    /// <summary>Send (or schedule) a broadcast.</summary>
    public Task SendAsync(Guid id, CancellationToken ct = default)
        => _client.PostAsync($"broadcasts/{id}/send", null, ct);

    /// <summary>Cancel a queued or scheduled broadcast.</summary>
    public Task CancelAsync(Guid id, CancellationToken ct = default)
        => _client.PostAsync($"broadcasts/{id}/cancel", null, ct);

    /// <summary>Duplicate a broadcast. Returns the new broadcast ID.</summary>
    public Task<Guid> DuplicateAsync(Guid id, CancellationToken ct = default)
        => _client.PostAsync<Guid>($"broadcasts/{id}/duplicate", null, ct);

    /// <summary>Delete a broadcast.</summary>
    public Task DeleteAsync(Guid id, CancellationToken ct = default)
        => _client.DeleteAsync($"broadcasts/{id}", ct);
}
