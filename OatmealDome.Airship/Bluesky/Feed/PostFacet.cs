using System.Text.Json.Serialization;
using OatmealDome.Airship.Bluesky.Feed.Facets;

namespace OatmealDome.Airship.Bluesky.Feed;

public class PostFacet
{
    [JsonPropertyName("index")]
    public FacetRange Index
    {
        get;
        set;
    }

    [JsonPropertyName("features")]
    public List<GenericFeature> Features
    {
        get;
        set;
    }
}