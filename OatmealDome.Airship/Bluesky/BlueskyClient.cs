using OatmealDome.Airship.ATProtocol;
using OatmealDome.Airship.ATProtocol.Lexicon.Types;
using OatmealDome.Airship.ATProtocol.Repo;
using OatmealDome.Airship.Bluesky.Feed;

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
    
    //
    // Post
    //
    
    public async Task<StrongRef> Post_Create(Post post)
    {
        VerifyCredentials();
        
        return await Repo_CreateRecord(Credentials!.Did, "app.bsky.feed.post", post);
    } 
}
