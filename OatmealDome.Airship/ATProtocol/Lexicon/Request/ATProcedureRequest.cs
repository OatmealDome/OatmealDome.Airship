using System.Text.Json.Serialization;

namespace OatmealDome.Airship.ATProtocol.Lexicon.Request;

public abstract class ATProcedureRequest : ATRequest
{
    [JsonIgnore]
    public override HttpMethod Method => HttpMethod.Post;
    
    public override FormUrlEncodedContent? CreateFormUrlEncodedContent()
    {
        // TODO: is there a procedure endpoint that uses query parameters?
        return null;
    }
}
