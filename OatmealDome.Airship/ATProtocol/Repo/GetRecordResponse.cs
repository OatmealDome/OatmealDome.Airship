using System.Text.Json.Serialization;
using OatmealDome.Airship.ATProtocol.Response;

namespace OatmealDome.Airship.ATProtocol.Repo;

public class GetRecordResponse<T> : ATJsonResponse where T : ATRecord
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

    [JsonPropertyName("value")]
    public T Value
    {
        get;
        set;
    }
}