using OatmealDome.Airship.ATProtocol;

namespace OatmealDome.Airship.Bluesky;

public sealed class BlueskyClient : ATClient
{
    public const string BaseUrl = "https://bsky.social";
    
    public BlueskyClient(HttpClient httpClient, string baseUrl) : base(httpClient, baseUrl)
    {
    }

    public BlueskyClient(string baseUrl) : base(baseUrl)
    {
    }

    public BlueskyClient(HttpClient httpClient) : base(httpClient, BaseUrl)
    {
    }

    public BlueskyClient() : base(BaseUrl)
    {
    }
}
