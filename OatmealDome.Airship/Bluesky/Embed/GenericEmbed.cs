using System.Text.Json.Serialization;
using OatmealDome.Airship.Bluesky.Embed.Json;

namespace OatmealDome.Airship.Bluesky.Embed;

[JsonConverter(typeof(GenericEmbedJsonConverter))]
public abstract class GenericEmbed
{
    //
}
