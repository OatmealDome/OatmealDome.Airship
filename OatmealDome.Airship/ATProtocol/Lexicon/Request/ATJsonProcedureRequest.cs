using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using DotNext.Text.Json;

namespace OatmealDome.Airship.ATProtocol.Lexicon.Request;

public abstract class ATJsonProcedureRequest : ATProcedureRequest
{
    public override HttpContent? CreateHttpContent()
    {
        return new StringContent(JsonSerializer.Serialize(this, GetType()), Encoding.UTF8, "application/json");
    }
}
