using System.Text.Json.Serialization;
using OatmealDome.Airship.ATProtocol.Response;

namespace OatmealDome.Airship.ATProtocol.Repo;

public class CreateRecordResponse : ATJsonResponse
{
    [JsonPropertyName("uri")]
    public string Uri
    {
        get;
        set;
    }

    [JsonPropertyName("cid")]
    public string Cid
    {
        get;
        set;
    }
}
