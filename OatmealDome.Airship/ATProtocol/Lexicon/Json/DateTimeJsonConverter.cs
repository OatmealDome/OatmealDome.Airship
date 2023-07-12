using System.Text.Json;
using System.Text.Json.Serialization;

namespace OatmealDome.Airship.ATProtocol.Lexicon.Json;

public class DateTimeJsonConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateTime.Parse(reader.GetString()!);
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        if (value.Kind != DateTimeKind.Utc)
        {
            value = value.ToUniversalTime();
        }

        string str = value.ToString("O");
        
        writer.WriteStringValue(str);
    }
}
