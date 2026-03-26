namespace CastBrick.SDK;

/// <summary>Configuration options for the CastBrick SDK client.</summary>
public sealed class CastBrickOptions
{
    /// <summary>Your CastBrick API key.</summary>
    public string ApiKey { get; set; } = string.Empty;

    /// <summary>API base URL. Defaults to https://api.castbrick.co.</summary>
    public string BaseUrl { get; set; } = "https://api.castbrick.co";
}
