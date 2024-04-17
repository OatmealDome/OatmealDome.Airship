using System.Text.Json;
using System.Text.Json.Serialization;
using OatmealDome.Airship.ATProtocol.Lexicon.Types;
using OatmealDome.Airship.Bluesky.Embed.Record;

namespace OatmealDome.Airship.Bluesky.Embed.Json;

public class RecordEmbedJsonConverter : JsonConverter<RecordEmbed>
{
    public override RecordEmbed? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);

        JsonElement recordElement = document.RootElement.GetProperty("record");

        return new RecordEmbed()
        {
            Record = recordElement.Deserialize<StrongRef>(options)!
        };
    }

    public override void Write(Utf8JsonWriter writer, RecordEmbed value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        
        writer.WritePropertyName("$type");
        writer.WriteStringValue("app.bsky.embed.record");
        
        writer.WritePropertyName("record");
        JsonSerializer.Serialize(writer, value.Record, options);

        writer.WriteEndObject();
    }
}