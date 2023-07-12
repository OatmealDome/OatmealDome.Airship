using OatmealDome.Airship.ATProtocol.Lexicon.Request;

namespace OatmealDome.Airship.ATProtocol.Server;

internal class RefreshSessionRequest : ATEmptyBodyProcedureRequest
{
    public override string NamespacedId => "com.atproto.server.refreshSession";
}
