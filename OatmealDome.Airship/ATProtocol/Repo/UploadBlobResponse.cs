using System.Text.Json.Serialization;
using OatmealDome.Airship.ATProtocol.Lexicon.Types.Blob;
using OatmealDome.Airship.ATProtocol.Response;

namespace OatmealDome.Airship.ATProtocol.Repo;

public class UploadBlobResponse : ATJsonResponse
{
    [JsonPropertyName("blob")]
    public GenericBlob Blob
    {
        get;
        set;
    }
}
