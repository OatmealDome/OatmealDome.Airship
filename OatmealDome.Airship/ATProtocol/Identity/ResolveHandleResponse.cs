using System.Text.Json.Serialization;
using OatmealDome.Airship.ATProtocol.Response;

namespace OatmealDome.Airship.ATProtocol.Identity;

public class ResolveHandleResponse : ATJsonResponse
{
    [JsonPropertyName("did")]
    public string Did
    {
        get;
        set;
    }
}
