using System.Text.Json.Serialization;
using OatmealDome.Airship.ATProtocol.Lexicon.Types;

namespace OatmealDome.Airship.Bluesky.Feed;

public class PostReply
{
    [JsonPropertyName("root")]
    public StrongRef Root
    {
        get;
        set;
    }

    [JsonPropertyName("parent")]
    public StrongRef Parent
    {
        get;
        set;
    }
}