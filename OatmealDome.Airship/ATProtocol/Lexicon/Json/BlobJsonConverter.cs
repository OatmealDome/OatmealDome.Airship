using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using OatmealDome.Airship.ATProtocol.Lexicon.Types.Blob;

namespace OatmealDome.Airship.ATProtocol.Lexicon.Json;

public class BlobJsonConverter : JsonConverter<GenericBlob>
{
    public override GenericBlob? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);

        bool isModern = false;

        if (document.RootElement.TryGetProperty("$type", out JsonElement typeElement))
        {
            if (typeElement.GetString() == "blob")
            {
                isModern = true;
            }
        }

        if (isModern)
        {
            return document.Deserialize<ModernBlob>(options);
        }

        // TODO: Blobs without a $type are considered to be in the legacy format.
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, GenericBlob value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, (object)value, options);
    }
}
