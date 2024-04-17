using System.Text.Json.Serialization;
using OatmealDome.Airship.ATProtocol.Lexicon.Types;
using OatmealDome.Airship.Bluesky.Embed.Json;

namespace OatmealDome.Airship.Bluesky.Embed.Record;

[JsonConverter(typeof(RecordEmbedJsonConverter))]
public class RecordEmbed : GenericEmbed
{
    [JsonPropertyName("record")]
    public StrongRef Record
    {
        get;
        set;
    }
}
