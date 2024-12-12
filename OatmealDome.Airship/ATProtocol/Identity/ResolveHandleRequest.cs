using OatmealDome.Airship.ATProtocol.Lexicon.Request;

namespace OatmealDome.Airship.ATProtocol.Identity;

public class ResolveHandleRequest : ATQueryRequest
{
    public override string NamespacedId => "com.atproto.identity.resolveHandle";
    
    [ATQueryRequestParameterName("handle")]
    public string Handle
    {
        get;
        set;
    }
}