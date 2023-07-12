using System.Text.Json.Serialization;
using OatmealDome.Airship.ATProtocol.Lexicon.Json;
using OatmealDome.Airship.ATProtocol.Repo;

namespace OatmealDome.Airship.Bluesky.Feed;

public class Post : ATRecord
{
    [JsonPropertyName("text")]
    public string Text
    {
        get;
        set;
    }
    
    [JsonPropertyName("createdAt")]
    [JsonConverter(typeof(DateTimeJsonConverter))]
    public DateTime CreatedAt
    {
        get;
        set;
    }
}
