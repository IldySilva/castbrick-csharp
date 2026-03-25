namespace CastBrick.SDK;

/// <summary>Thrown when the CastBrick API returns a non-success HTTP status.</summary>
public sealed class CastBrickApiException : Exception
{
    /// <summary>HTTP status code returned by the API.</summary>
    public int StatusCode { get; }

    public CastBrickApiException(int statusCode, string message)
        : base($"CastBrick API error {statusCode}: {message}")
    {
        StatusCode = statusCode;
    }
}
