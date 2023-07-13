using System.Text.Json;
using System.Text.Json.Serialization;
using OatmealDome.Airship.Bluesky.Embed.Image;

namespace OatmealDome.Airship.Bluesky.Embed.Json;

public class ImagesEmbedJsonConverter : JsonConverter<ImagesEmbed>
{
    public override ImagesEmbed? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);

        JsonElement imagesElement = document.RootElement.GetProperty("images");

        List<EmbeddedImage> images = new List<EmbeddedImage>();

        for (int i = 0; i < imagesElement.GetArrayLength(); i++)
        {
            images.Add(imagesElement[i].Deserialize<EmbeddedImage>(options)!);
        }

        return new ImagesEmbed()
        {
            Images = images
        };
    }

    public override void Write(Utf8JsonWriter writer, ImagesEmbed value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        
        writer.WritePropertyName("$type");
        writer.WriteStringValue("app.bsky.embed.images");
        
        writer.WritePropertyName("images");
        writer.WriteStartArray();
        
        foreach (EmbeddedImage image in value.Images)
        {
            JsonSerializer.Serialize(writer, image, options);
        }
        
        writer.WriteEndArray();

        writer.WriteEndObject();
    }
}
