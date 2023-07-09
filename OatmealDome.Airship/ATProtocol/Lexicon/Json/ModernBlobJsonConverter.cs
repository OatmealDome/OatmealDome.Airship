using System.Text.Json;
using System.Text.Json.Serialization;
using OatmealDome.Airship.ATProtocol.Lexicon.Types;
using OatmealDome.Airship.ATProtocol.Lexicon.Types.Blob;

namespace OatmealDome.Airship.ATProtocol.Lexicon.Json;

public class ModernBlobJsonConverter : JsonConverter<ModernBlob>
{
    public override ModernBlob? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        
        JsonElement rootElement = document.RootElement;

        return new ModernBlob()
        {
            Ref = rootElement.GetProperty("ref").Deserialize<Link>(options)!,
            MimeType = rootElement.GetProperty("mimeType").GetString()!,
            Size = rootElement.GetProperty("size").GetInt32()
        };
    }

    public override void Write(Utf8JsonWriter writer, ModernBlob value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        
        writer.WritePropertyName("$type");
        writer.WriteStringValue("blob");
        
        writer.WritePropertyName("ref");
        writer.WriteRawValue(JsonSerializer.Serialize(value.Ref, options));
        
        writer.WritePropertyName("mimeType");
        writer.WriteStringValue(value.MimeType);
        
        writer.WritePropertyName("size");
        writer.WriteNumberValue(value.Size);
        
        writer.WriteEndObject();
    }
}
