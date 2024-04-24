using System.Text.Json;
using System.Text.Json.Serialization;
using OatmealDome.Airship.ATProtocol.Lexicon.Types;
using OatmealDome.Airship.Bluesky.Embed.Record;

namespace OatmealDome.Airship.Bluesky.Feed.Facets.Json;

public class LinkFeatureJsonConverter : JsonConverter<LinkFeature>
{
    public override LinkFeature? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);

        JsonElement uriElement = document.RootElement.GetProperty("uri");

        return new LinkFeature()
        {
            Uri = uriElement.GetString()!
        };
    }

    public override void Write(Utf8JsonWriter writer, LinkFeature value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        
        writer.WritePropertyName("$type");
        writer.WriteStringValue("app.bsky.richtext.facet#link");
        
        writer.WritePropertyName("uri");
        JsonSerializer.Serialize(writer, value.Uri, options);

        writer.WriteEndObject();
    }
}