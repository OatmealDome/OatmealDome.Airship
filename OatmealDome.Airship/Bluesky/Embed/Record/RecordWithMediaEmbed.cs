using System.Text.Json.Serialization;
using OatmealDome.Airship.ATProtocol.Lexicon.Types;
using OatmealDome.Airship.Bluesky.Embed.Json;

namespace OatmealDome.Airship.Bluesky.Embed.Record;

[JsonConverter(typeof(RecordWithMediaEmbedJsonConverter))]
public class RecordWithMediaEmbed : GenericEmbed
{
    [JsonPropertyName("record")]
    public RecordEmbed RecordEmbed
    {
        get;
        set;
    }

    [JsonPropertyName("media")]
    public GenericEmbed MediaEmbed
    {
        get;
        set;
    }
}