using System.Text.Json.Serialization;

namespace OatmealDome.Airship.ATProtocol.Lexicon.Request;

public abstract class ATProcedureRequest : ATRequest
{
    [JsonIgnore]
    public override HttpMethod Method => HttpMethod.Post;
}
