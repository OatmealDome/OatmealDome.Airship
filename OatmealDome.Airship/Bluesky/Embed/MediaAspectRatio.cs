using System.Text.Json.Serialization;

namespace OatmealDome.Airship.Bluesky.Embed;

public class MediaAspectRatio
{
    [JsonPropertyName("width")]
    public int Width
    {
        get;
        set;
    }
    
    [JsonPropertyName("height")]
    public int Height
    {
        get;
        set;
    }
}