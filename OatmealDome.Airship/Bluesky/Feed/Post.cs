using System.Text.Json.Serialization;
using DotNext;
using DotNext.Text.Json;
using OatmealDome.Airship.ATProtocol.Lexicon.Json;
using OatmealDome.Airship.ATProtocol.Repo;
using OatmealDome.Airship.Bluesky.Embed;

namespace OatmealDome.Airship.Bluesky.Feed;

public class Post : ATRecord
{
    [JsonPropertyName("text")]
    public string Text
    {
        get;
        set;
    }
    
    [JsonPropertyName("embed")]
    [JsonConverter(typeof(OptionalConverterFactory))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<GenericEmbed> Embed
    {
        get;
        set;
    }
    
    [JsonPropertyName("reply")]
    [JsonConverter(typeof(OptionalConverterFactory))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<PostReply> Reply
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
