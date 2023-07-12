using System.Text.Json.Serialization;

namespace OatmealDome.Airship.ATProtocol.Lexicon.Request;

public abstract class ATRequest
{
    public abstract string NamespacedId
    {
        get;
    }

    public abstract HttpMethod Method
    {
        get;
    }

    // public abstract void Validate();

    public abstract HttpContent? CreateHttpContent();
}
