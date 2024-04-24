using System.Text.Json.Serialization;
using OatmealDome.Airship.Bluesky.Feed.Facets.Json;

namespace OatmealDome.Airship.Bluesky.Feed.Facets;

[JsonConverter(typeof(LinkFeatureJsonConverter))]
public class LinkFeature : GenericFeature
{
    [JsonPropertyName("uri")]
    public string Uri
    {
        get;
        set;
    }
}