using System.Text.Json;
using System.Text.Json.Serialization;
using OatmealDome.Airship.ATProtocol.Lexicon.Types;

namespace OatmealDome.Airship.ATProtocol.Lexicon.Json;

public class BytesJsonConverter : JsonConverter<Bytes>
{
    public override Bytes? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        
        byte[] data = document.RootElement.GetProperty("$bytes").GetBytesFromBase64();

        return new Bytes(data);
    }

    public override void Write(Utf8JsonWriter writer, Bytes value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WritePropertyName("$bytes");
        writer.WriteBase64StringValue(value.Data);
        writer.WriteEndObject();
    }
}
