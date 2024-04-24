using System.Text.Json.Serialization;
using OatmealDome.Airship.Bluesky.Feed.Facets.Json;

namespace OatmealDome.Airship.Bluesky.Feed.Facets;

[JsonConverter(typeof(GenericFeatureJsonConverter))]
public abstract class GenericFeature
{
    
}