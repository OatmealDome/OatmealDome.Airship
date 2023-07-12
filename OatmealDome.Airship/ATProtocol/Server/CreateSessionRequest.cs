using System.Text.Json.Serialization;
using OatmealDome.Airship.ATProtocol.Lexicon.Request;

namespace OatmealDome.Airship.ATProtocol.Server;

internal class CreateSessionRequest : ATJsonProcedureRequest
{
    [JsonIgnore]
    public override string NamespacedId => "com.atproto.server.createSession";

    [JsonPropertyName("identifier")]
    public string Identifier
    {
        get;
        set;
    }

    [JsonPropertyName("password")]
    public string Password
    {
        get;
        set;
    }
}
