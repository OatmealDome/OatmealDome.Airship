using System.Text.Json.Serialization;
using OatmealDome.Airship.ATProtocol.Lexicon.Types.Blob;

namespace OatmealDome.Airship.Bluesky.Embed.Image;

public class EmbeddedImage
{
    [JsonPropertyName("image")]
    public GenericBlob Image
    {
        get;
        set;
    }

    [JsonPropertyName("alt")]
    public string AltText
    {
        get;
        set;
    }
}
