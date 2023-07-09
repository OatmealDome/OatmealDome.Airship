using System.Text.Json.Serialization;
using OatmealDome.Airship.ATProtocol.Lexicon.Json;

namespace OatmealDome.Airship.ATProtocol.Lexicon.Types.Blob;

[JsonConverter(typeof(ModernBlobJsonConverter))]
public sealed class ModernBlob : GenericBlob
{
    [JsonPropertyName("ref")]
    public Link Ref
    {
        get;
        set;
    }

    [JsonPropertyName("mimeType")]
    public string MimeType
    {
        get;
        set;
    }

    [JsonPropertyName("size")]
    public int Size
    {
        get;
        set;
    }
}
