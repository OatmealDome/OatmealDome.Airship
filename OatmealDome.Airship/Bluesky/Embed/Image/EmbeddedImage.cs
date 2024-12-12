using System.Text.Json.Serialization;
using DotNext;
using DotNext.Text.Json;
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

    [JsonPropertyName("aspectRatio")]
    [JsonConverter(typeof(OptionalConverterFactory))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<MediaAspectRatio> AspectRatio
    {
        get;
        set;
    } = Optional.None<MediaAspectRatio>();
}
