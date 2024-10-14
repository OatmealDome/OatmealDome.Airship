using System.Text.Json;
using System.Text.Json.Serialization;
using OatmealDome.Airship.Bluesky.Embed.Image;
using OatmealDome.Airship.Bluesky.Embed.Record;

namespace OatmealDome.Airship.Bluesky.Embed.Json;

public class GenericEmbedJsonConverter : JsonConverter<GenericEmbed>
{
    public override GenericEmbed? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);

        GenericEmbed? embed = null;

        if (document.RootElement.TryGetProperty("$type", out JsonElement typeElement))
        {
            string type = typeElement.GetString();

            if (type == null)
            {
                throw new FormatException("Type is null in embed");
            }
            
            if (type == "app.bsky.embed.images")
            {
                embed = document.Deserialize<ImagesEmbed>(options)!;
            }
            else if (type == "app.bsky.embed.record")
            {
                embed = document.Deserialize<RecordEmbed>(options)!;
            }
            else if (type == "app.bsky.embed.recordWithMedia")
            {
                embed = document.Deserialize<RecordWithMediaEmbed>(options)!;
            }
        }

        if (embed == null)
        {
            throw new NotImplementedException();
        }

        return embed;
    }

    public override void Write(Utf8JsonWriter writer, GenericEmbed value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
