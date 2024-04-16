using System.Text.Json.Serialization;

namespace OatmealDome.Airship.ATProtocol.Lexicon.Types;

// https://github.com/bluesky-social/atproto/blob/main/lexicons/com/atproto/repo/strongRef.json
public sealed class StrongRef
{
    [JsonPropertyName("uri")]
    public string Uri
    {
        get;
        set;
    }
    
    [JsonPropertyName("cid")]
    public string Cid
    {
        get;
        set;
    }

    public StrongRef()
    {
        Uri = "";
        Cid = "";
    }

    public StrongRef(string uri, string cid)
    {
        Uri = uri;
        Cid = cid;
    }
}