using System.Text.Json.Serialization;

namespace OatmealDome.Airship.Bluesky.Feed.Facets;

public class FacetRange
{
    [JsonPropertyName("byteStart")]
    public int ByteStart
    {
        get;
        set;
    }
    
    [JsonPropertyName("byteEnd")]
    public int ByteEnd
    {
        get;
        set;
    }
}