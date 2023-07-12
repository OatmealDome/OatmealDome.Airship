using System.Text.Json.Serialization;
using DotNext;
using DotNext.Text.Json;
using OatmealDome.Airship.ATProtocol.Lexicon.Request;

namespace OatmealDome.Airship.ATProtocol.Server;

internal class CreateAccountRequest : ATJsonProcedureRequest
{
    [JsonIgnore]
    public override string NamespacedId => "com.atproto.server.createAccount";
    
    [JsonPropertyName("email")]
    public string Email
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

    [JsonPropertyName("inviteCode")]
    [JsonConverter(typeof(OptionalConverterFactory))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<string> InviteCode
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

    [JsonPropertyName("recoveryKey")]
    [JsonConverter(typeof(OptionalConverterFactory))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<string> RecoveryKey
    {
        get;
        set;
    }
}
