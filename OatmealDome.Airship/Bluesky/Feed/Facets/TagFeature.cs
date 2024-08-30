using System.Text.Json.Serialization;
using OatmealDome.Airship.Bluesky.Feed.Facets.Json;

namespace OatmealDome.Airship.Bluesky.Feed.Facets;

[JsonConverter(typeof(TagFeatureJsonConverter))]
public class TagFeature : GenericFeature
{
    [JsonPropertyName("tag")]
    public string Tag
    {
        get;
        set;
    }
}