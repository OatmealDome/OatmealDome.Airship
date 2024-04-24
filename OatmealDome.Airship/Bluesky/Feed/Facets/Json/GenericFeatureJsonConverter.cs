using System.Text.Json;
using System.Text.Json.Serialization;

namespace OatmealDome.Airship.Bluesky.Feed.Facets.Json;

public class GenericFeatureJsonConverter : JsonConverter<GenericFeature>
{
    public override GenericFeature? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);

        GenericFeature? feature = null;

        if (document.RootElement.TryGetProperty("$type", out JsonElement typeElement))
        {
            string? type = typeElement.GetString();

            if (type == null)
            {
                throw new FormatException("Type is null in feature");
            }
        }

        if (feature == null)
        {
            throw new NotImplementedException();
        }

        return feature;
    }

    public override void Write(Utf8JsonWriter writer, GenericFeature value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}