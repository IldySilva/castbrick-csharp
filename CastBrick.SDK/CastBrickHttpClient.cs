using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CastBrick.SDK;

internal sealed class CastBrickHttpClient
{
    private readonly HttpClient _http;

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    };

    internal CastBrickHttpClient(HttpClient http, CastBrickOptions options)
    {
        if (string.IsNullOrWhiteSpace(options.ApiKey))
            throw new ArgumentException("ApiKey is required.", nameof(options));

        http.BaseAddress = new Uri(options.BaseUrl.TrimEnd('/') + "/");
        http.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", options.ApiKey);

        _http = http;
    }

    internal async Task<T> GetAsync<T>(string path, CancellationToken ct = default)
    {
        var response = await _http.GetAsync(path, ct);
        return await HandleAsync<T>(response, ct);
    }

    internal async Task<T> PostAsync<T>(string path, object? body = null, CancellationToken ct = default)
    {
        var response = await _http.PostAsJsonAsync(path, body, JsonOptions, ct);
        return await HandleAsync<T>(response, ct);
    }

    internal async Task PostAsync(string path, object? body = null, CancellationToken ct = default)
    {
        var response = await _http.PostAsJsonAsync(path, body, JsonOptions, ct);
        await EnsureSuccessAsync(response, ct);
    }

    internal async Task<T> PutAsync<T>(string path, object body, CancellationToken ct = default)
    {
        var response = await _http.PutAsJsonAsync(path, body, JsonOptions, ct);
        return await HandleAsync<T>(response, ct);
    }

    internal async Task DeleteAsync(string path, CancellationToken ct = default)
    {
        var response = await _http.DeleteAsync(path, ct);
        await EnsureSuccessAsync(response, ct);
    }

    private static async Task<T> HandleAsync<T>(HttpResponseMessage response, CancellationToken ct)
    {
        await EnsureSuccessAsync(response, ct);
        if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            return default!;
        return (await response.Content.ReadFromJsonAsync<T>(JsonOptions, ct))!;
    }

    private static async Task EnsureSuccessAsync(HttpResponseMessage response, CancellationToken ct)
    {
        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            throw new CastBrickApiException((int)response.StatusCode, body);
        }
    }
}
