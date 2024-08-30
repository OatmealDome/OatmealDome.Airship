using System.Text.Json;
using System.Text.Json.Serialization;

namespace OatmealDome.Airship.Bluesky.Feed.Facets.Json;

public class TagFeatureJsonConverter : JsonConverter<TagFeature>
{
    public override TagFeature? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);

        JsonElement tagElement = document.RootElement.GetProperty("tag");

        return new TagFeature()
        {
            Tag = tagElement.GetString()!
        };
    }

    public override void Write(Utf8JsonWriter writer, TagFeature value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        
        writer.WritePropertyName("$type");
        writer.WriteStringValue("app.bsky.richtext.facet#tag");
        
        writer.WritePropertyName("tag");
        JsonSerializer.Serialize(writer, value.Tag, options);

        writer.WriteEndObject();
    }
}