using System.Text.Json;
using System.Text.Json.Serialization;
using OatmealDome.Airship.ATProtocol.Lexicon.Types;
using OatmealDome.Airship.Bluesky.Embed.Image;
using OatmealDome.Airship.Bluesky.Embed.Record;

namespace OatmealDome.Airship.Bluesky.Embed.Json;

public class RecordWithMediaEmbedJsonConverter : JsonConverter<RecordWithMediaEmbed>
{
    public override RecordWithMediaEmbed? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);

        JsonElement recordElement = document.RootElement.GetProperty("record");
        JsonElement mediaElement = document.RootElement.GetProperty("media");

        return new RecordWithMediaEmbed()
        {
            Record = recordElement.Deserialize<StrongRef>(options)!,
            Media = mediaElement.Deserialize<GenericEmbed>(options)!
        };
    }

    public override void Write(Utf8JsonWriter writer, RecordWithMediaEmbed value, JsonSerializerOptions options)
    {
        if (value.Media is not ImagesEmbed)
        {
            throw new BlueskyException("Media embed in RecordWithMediaEmbed must be an ImagesEmbed");
        }
        
        writer.WriteStartObject();
        
        writer.WritePropertyName("$type");
        writer.WriteStringValue("app.bsky.embed.recordWithMedia");
        
        writer.WritePropertyName("record");
        JsonSerializer.Serialize(writer, value.Record, options);
        
        writer.WritePropertyName("media");
        JsonSerializer.Serialize(writer, value.Media, options);

        writer.WriteEndObject();
    }
}