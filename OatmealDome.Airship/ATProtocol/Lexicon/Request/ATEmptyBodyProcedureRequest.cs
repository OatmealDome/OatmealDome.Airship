namespace OatmealDome.Airship.ATProtocol.Lexicon.Request;

public abstract class ATEmptyBodyProcedureRequest : ATProcedureRequest
{
    public override HttpContent? CreateHttpContent()
    {
        return null;
    }
}
