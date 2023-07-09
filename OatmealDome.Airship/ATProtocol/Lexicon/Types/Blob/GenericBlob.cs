using System.Text.Json.Serialization;
using OatmealDome.Airship.ATProtocol.Lexicon.Json;

namespace OatmealDome.Airship.ATProtocol.Lexicon.Types.Blob;

[JsonConverter(typeof(BlobJsonConverter))]
public abstract class GenericBlob
{
    //
}
