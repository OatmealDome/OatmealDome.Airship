using System.Text.Json.Serialization;
using DotNext;
using DotNext.Text.Json;
using OatmealDome.Airship.ATProtocol.Response;

namespace OatmealDome.Airship.ATProtocol.Server;

internal class CreateSessionResponse : ATJsonResponse
{
    [JsonPropertyName("accessJwt")]
    public string AccessJwt
    {
        get;
        set;
    }

    [JsonPropertyName("refreshJwt")]
    public string RefreshJwt
    {
        get;
        set;
    }

    [JsonPropertyName("handle")]
    public string Handle
    {
        get;
        set;
    }

    [JsonPropertyName("did")]
    public string Did
    {
        get;
        set;
    }
    
    [JsonPropertyName("email")]
    [JsonConverter(typeof(OptionalConverterFactory))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<string> Email
    {
        get;
        set;
    }
}
