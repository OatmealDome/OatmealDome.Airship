using System.Text.Json;
using System.Text.Json.Serialization;
using OatmealDome.Airship.Bluesky.Embed.Image;

namespace OatmealDome.Airship.Bluesky.Embed.Json;

public class GenericEmbedJsonConverter : JsonConverter<GenericEmbed>
{
    public override GenericEmbed? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);

        GenericEmbed? embed = null;

        if (document.RootElement.TryGetProperty("$type", out JsonElement typeElement))
        {
            if (typeElement.GetString() == "app.bsky.embed.images")
            {
                embed = document.Deserialize<ImagesEmbed>(options)!;
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
