using System.Text.Json.Serialization;

namespace OatmealDome.Airship.ATProtocol;

public sealed class ATError
{
    [JsonPropertyName("error")]
    public string Error
    {
        get;
        set;
    }

    [JsonPropertyName("message")]
    public string? Message
    {
        get;
        set;
    }
}
