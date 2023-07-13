using System.Text.Json.Serialization;
using OatmealDome.Airship.Bluesky.Embed.Json;

namespace OatmealDome.Airship.Bluesky.Embed.Image;

[JsonConverter(typeof(ImagesEmbedJsonConverter))]
public class ImagesEmbed : GenericEmbed
{
    [JsonPropertyName("images")]
    public List<EmbeddedImage> Images
    {
        get;
        set;
    }
}
