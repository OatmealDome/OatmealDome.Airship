using System.Text.Json.Serialization;
using OatmealDome.Airship.ATProtocol.Lexicon.Types.Blob;

namespace OatmealDome.Airship.Bluesky.Embed.Video;

public class VideoCaptionFile
{
    [JsonPropertyName("language")]
    public string Language
    {
        get;
        set;
    }

    [JsonPropertyName("file")]
    public GenericBlob Blob
    {
        get;
        set;
    }
}