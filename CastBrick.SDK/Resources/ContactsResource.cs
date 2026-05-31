using CastBrick.SDK.Models;
using CastBrick.SDK.Models.Contacts;

namespace CastBrick.SDK.Resources;

/// <summary>Contacts and contact lists operations.</summary>
public sealed class ContactsResource
{
    private readonly CastBrickHttpClient _client;

    internal ContactsResource(CastBrickHttpClient client) => _client = client;

    // ─── Contacts ────────────────────────────────────────────────────────────

    /// <summary>List contacts (paginated).</summary>
    public Task<PagedResult<Contact>> ListAsync(int page = 1, int pageSize = 20, string? search = null, CancellationToken ct = default)
    {
        var url = $"audience/contacts?pageNumber={page}&pageSize={pageSize}";
        if (!string.IsNullOrWhiteSpace(search)) url += $"&search={Uri.EscapeDataString(search)}";
        return _client.GetAsync<PagedResult<Contact>>(url, ct);
    }

    /// <summary>Get a contact by ID.</summary>
    public Task<Contact> GetAsync(Guid id, CancellationToken ct = default)
        => _client.GetAsync<Contact>($"audience/contacts/{id}", ct);

    /// <summary>Create contacts from comma/newline-separated phone numbers.</summary>
    public Task CreateAsync(CreateContactRequest request, CancellationToken ct = default)
        => _client.PostAsync("audience/contacts", request, ct);

    /// <summary>Delete a contact.</summary>
    public Task DeleteAsync(Guid id, CancellationToken ct = default)
        => _client.DeleteAsync($"audience/contacts/{id}", ct);

    // ─── Contact Lists ────────────────────────────────────────────────────────

    /// <summary>List all contact lists.</summary>
    public Task<PagedResult<ContactList>> ListListsAsync(int page = 1, int pageSize = 20, CancellationToken ct = default)
        => _client.GetAsync<PagedResult<ContactList>>($"audience/lists?pageNumber={page}&pageSize={pageSize}", ct);

    /// <summary>Get a contact list by ID.</summary>
    public Task<ContactList> GetListAsync(Guid id, CancellationToken ct = default)
        => _client.GetAsync<ContactList>($"audience/lists/{id}", ct);

    /// <summary>Create a contact list. Returns the ID of the created list.</summary>
    public Task<Guid> CreateListAsync(string name, CancellationToken ct = default)
        => _client.PostAsync<Guid>("audience/lists", new { name }, ct);

    /// <summary>Add a contact to a list.</summary>
    public Task AddToListAsync(Guid listId, Guid contactId, CancellationToken ct = default)
        => _client.PostAsync($"audience/lists/{listId}/contacts", new { contactId }, ct);

    /// <summary>Remove a contact from a list.</summary>
    public Task RemoveFromListAsync(Guid listId, Guid contactId, CancellationToken ct = default)
        => _client.DeleteAsync($"audience/lists/{listId}/contacts/{contactId}", ct);
}
