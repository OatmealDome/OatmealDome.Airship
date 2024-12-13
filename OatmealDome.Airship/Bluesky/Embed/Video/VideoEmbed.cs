using System.Text.Json.Serialization;
using DotNext;
using DotNext.Text.Json;
using OatmealDome.Airship.ATProtocol.Lexicon.Types.Blob;
using OatmealDome.Airship.Bluesky.Embed.Json;

namespace OatmealDome.Airship.Bluesky.Embed.Video;

[JsonConverter(typeof(VideoEmbedJsonConverter))]
public class VideoEmbed : GenericEmbed
{
    [JsonPropertyName("video")]
    public GenericBlob Video
    {
        get;
        set;
    }

    [JsonPropertyName("captions")]
    [JsonConverter(typeof(OptionalConverterFactory))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<List<VideoCaptionFile>> CaptionFiles
    {
        get;
        set;
    } = Optional<List<VideoCaptionFile>>.None;

    [JsonPropertyName("alt")]
    [JsonConverter(typeof(OptionalConverterFactory))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<string> AltText
    {
        get;
        set;
    } = Optional<string>.None;

    [JsonPropertyName("aspectRatio")]
    [JsonConverter(typeof(OptionalConverterFactory))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<MediaAspectRatio> AspectRatio
    {
        get;
        set;
    } = Optional.None<MediaAspectRatio>();
}