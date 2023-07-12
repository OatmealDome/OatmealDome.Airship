using System.Text.Json.Serialization;
using OatmealDome.Airship.ATProtocol.Response;

namespace OatmealDome.Airship.ATProtocol.Server;

internal class CreateAccountResponse : ATJsonResponse
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
}
